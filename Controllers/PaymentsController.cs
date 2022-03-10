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
    [Route("api/Payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IinvoicePayment _repo;

        public PaymentsController(IinvoicePayment repo) //create constructor
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllthePayments()
        {
            try
            {
                return Ok(await _repo.GetAllPayments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost("MakePayment")]
        public async Task<IActionResult> CreateAPayment([FromBody] InvoicePayments payment)
        {
            if (payment == null)
                return BadRequest();
            await _repo.CreatePayment(payment);
            return Ok();
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult> GetCustomerPaymentList(Int64 customerId)
        {
            var account = await _repo.GetPaymentsByCustomerId(customerId);
            return Ok(account);
        }

    }
}
