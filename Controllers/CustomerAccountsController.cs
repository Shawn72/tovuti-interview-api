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
    [Route("api/CustomerAccounts")]
    public class CustomerAccountsController : ControllerBase
    {
        private readonly ICustomerAccounts _repo;

        public CustomerAccountsController(ICustomerAccounts repo) //create constructor
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCustomerAccount()
        {
            try
            {
                return Ok(await _repo.GetAllCustomerAccounts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost("createcstaccount")]
        public async Task<IActionResult> CreateCustomerAccount([FromBody] CustomerAccounts account )
        {
            if (account == null)
                return BadRequest();
            await _repo.CreateCustomerAccount(account);
            return Ok();
        }

        [HttpGet("{customerId}")]
        public IActionResult GetCustomerAccount(Int64 id)
        {
            var account = _repo.GetCustomerAccount(id);
            return Ok(account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAccount(Int64 id, [FromBody] CustomerAccounts account)
        {
            // additional product and model validation checks
            var dbAccount = _repo.GetCustomerAccount(id);
            if (dbAccount == null)
                return NotFound();
            await _repo.UpdateCustomerAccount(account, dbAccount);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAccount(Int64 id)
        {
            var account = _repo.GetCustomerAccount(id);
            if (account == null)
                return NotFound();
            await _repo.DeleteCustomerAccount(account);
            return Ok();
        }
    }
}
