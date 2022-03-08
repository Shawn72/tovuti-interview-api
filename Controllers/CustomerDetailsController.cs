using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TovutiAPI.Auths;
using TovutiAPI.Entities;
using TovutiAPI.Interface;

namespace TovutiAPI.Controllers
{
    [BasicAuthentication]
    [ApiController]
    [Route("api/customerdetails")]
    public class CustomerDetailsController : ControllerBase
    { 
        private readonly ICustomerDetails _repo;        

        public CustomerDetailsController(ICustomerDetails repo) //create constructor
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllCustomerDetails()
        {
            try
            {
                return Ok(await _repo.GetAllCustomerDetails());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }  

        [HttpPost("createcstdetails")]
        public async Task<IActionResult> CreateCustomerDetails([FromBody] CustomerDetails customerdetails)
        {
            if (customerdetails == null)
                return BadRequest();
            await _repo.CreateCustomerDetails(customerdetails);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerDetails(Int64 id)
        {
            var customer = _repo.GetCustomerDetail(id);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerDetail(Int64 id, [FromBody] CustomerDetails cstdetails)
        {
            // additional product and model validation checks

            var dbCstDetails = _repo.GetCustomerDetail(id);
            if (dbCstDetails == null)
                return NotFound();
            await _repo.UpdateCustomerDetail(cstdetails, dbCstDetails);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDetail(Int64 id)
        {
            var customer = _repo.GetCustomerDetail(id);
            if (customer == null)
                return NotFound();
            await _repo.DeleteCustomerDetail(customer);
            return Ok();
        }
    }
}
