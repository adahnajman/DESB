using Exercise.Data;
using Exercise.Interfaces;
using Exercise.Models.ViewModel;
using Exercise.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;


namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public CustomerContext _Context { get; set; }
        private readonly ILogger<LoginController> _logger;
        private readonly ITokenService _tokenService;
        public LoginController(CustomerContext context, ILogger<LoginController> logger, ITokenService tokenService)
        {
            _Context = context;
            _logger = logger;
            _tokenService = tokenService;
        }

        public static class HashHelper
        {
            public static string ComputeMD5Hash(string input)
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
        }

    [HttpPost("api/Login")]
        public async Task<IActionResult> Login(UserVM model)
        {
            try
            {
                var user = await _Context.TblUsers.SingleOrDefaultAsync(x => x.UserName.Equals(model.UserName, StringComparison.Ordinal) && x.Password == HashHelper.ComputeMD5Hash(model.Password));
                if (user != null)
                {
                    var token = _tokenService.GenerateToken(model);
                    Response.Cookies.Append("token", token);
                    return Ok(new { Token = token });
                }
                else
                {
                    return BadRequest("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }

    }
}
