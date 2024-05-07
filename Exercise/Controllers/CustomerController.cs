using Exercise.Data;
using Exercise.Entities;
using Exercise.Models;
using Exercise.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CustomerController : ControllerBase
    {
        public CustomerContext _Context { get; set; }
        private readonly ILogger<CustomerController> _logger;
        public CustomerController (CustomerContext context, ILogger<CustomerController> logger) 
        { 
            _Context = context;
            _logger = logger;
        }

        #region add
        [HttpPost("AddNewCustomer")]
        public async Task<ActionResult<CustomerVM>> AddCustomer(CustomerVM customer)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (customer != null)
                    {
                        TblCustomer a = new TblCustomer();
                        a.CustomerID = customer.CustomerID;
                        a.CustomerName = customer.CustomerName;
                        a.CustomerAddress1 = customer.CustomerAddress1;
                        a.CustomerAddress2 = customer.CustomerAddress2;
                        a.Email = customer.Email;
                        a.PhoneNo = customer.PhoneNo;
                        a.Language = JsonConvert.SerializeObject(customer.Language);
                        a.Height = customer.Height;
                        a.Weight = customer.Weight;
                        a.CreatedBy = 1;
                        a.CreatedAt = DateTime.Now;

                        string concatenatedLanguages = string.Join(",", customer.Language);
                        a.Language = concatenatedLanguages;
                        _Context.TblCustomers.Add(a);
                        await _Context.SaveChangesAsync();
                    }
                    return CreatedAtAction(nameof(AddCustomer), new { id = customer.Id }, customer);
                }
                else
                {
                    return CreatedAtAction(nameof(AddCustomer), new { id = customer.Id }, customer);
                }
                    
            }
            catch
            {
                return StatusCode(500, "An error occurred while adding the customer.");
            }
        }
        #endregion

        #region update
        [HttpGet("GetCustomerById/{Id}")]
        public async Task<ActionResult<CustomerVM>> GetCustomerById(int Id)
        {
            try
            {
                var existingCustomer = await _Context.TblCustomers.FindAsync(Id);
                if (existingCustomer == null)
                {
                    return NotFound();
                }

                var languages = existingCustomer.Language.Split(',').ToList(); 

                var customerVM = new CustomerVM
                {
                    CustomerID = existingCustomer.CustomerID,
                    CustomerName = existingCustomer.CustomerName,
                    CustomerAddress1 = existingCustomer.CustomerAddress1,
                    CustomerAddress2 = existingCustomer.CustomerAddress2,
                    PhoneNo = existingCustomer.PhoneNo,
                    Email = existingCustomer.Email,
                    Language = languages,
                    Height = (double)existingCustomer.Height,
                    Weight = (double)existingCustomer.Weight,
                    CreatedBy = (int)existingCustomer.CreatedBy,
                    CreatedAt = (DateTime)existingCustomer.CreatedAt,
                    Id = existingCustomer.Id
                };

                return Ok(customerVM);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the customer.");
            }
        }

        [HttpPut("{Id}")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdateCustomer(int Id, CustomerVM customer)
        {
            try
            {
                var existingCustomer = await _Context.TblCustomers.FindAsync(Id);
                if (existingCustomer == null)
                {
                    return NotFound();
                }

                existingCustomer.CustomerID = customer.CustomerID;
                existingCustomer.CustomerName = customer.CustomerName;
                existingCustomer.CustomerAddress1 = customer.CustomerAddress1;
                existingCustomer.CustomerAddress2 = customer.CustomerAddress2;
                existingCustomer.PhoneNo = customer.PhoneNo;
                existingCustomer.Email = customer.Email;
                existingCustomer.Weight = customer.Weight;
                existingCustomer.Height = customer.Height;
                existingCustomer.UpdatedBy = 1;
                existingCustomer.UpdatedAt = DateTime.Now;

                string concatenatedLanguages = string.Join(",", customer.Language);
                existingCustomer.Language = concatenatedLanguages;

                _Context.SaveChanges();

                return Ok(existingCustomer);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the customer.");
            }
        }
        #endregion

        #region delete
        [HttpDelete("{Id}")]
        public IActionResult DeleteCustomer(int Id) 
        {
            try
            {
                var existingCustomer = _Context.TblCustomers.Find(Id);
                if (existingCustomer == null)
                {
                    return NotFound();
                }

                _Context.Remove(existingCustomer);
                _Context.SaveChanges();

                return StatusCode(200, "Successfully Deleted");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the customer.");
            }
        }
        #endregion

        #region search record
        [HttpGet("SearchData")]
        public async Task<ActionResult<IEnumerable<CustomerVM>>> SearchCustomer(string data)
        {
            try
            {
                if (data != null && !string.IsNullOrEmpty(data))
                {
                    var query = await _Context.TblCustomers
                              .Where(x =>
                                  x.CustomerName.Contains(data) ||
                                  x.CustomerAddress1.Contains(data) ||
                                  x.CustomerAddress2.Contains(data) ||
                                  x.Email.Contains(data)
                              )
                              .ToListAsync();

                    return Ok(query);
                }
                else
                {
                    return StatusCode(404, "No data Found");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while searching for customers.");
            }
        }

        #endregion

        #region list of customer
        [HttpGet("GetCustomerList")]
        public IActionResult GetCustomerList()
        {
            var customerList = _Context.TblCustomers.ToList();

            return Ok(customerList);
        }

        #endregion

        #region login at blazor
        #endregion
    }
}
