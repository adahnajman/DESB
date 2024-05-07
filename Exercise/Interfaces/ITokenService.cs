using Exercise.Models.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Exercise.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserVM user);
    }
}