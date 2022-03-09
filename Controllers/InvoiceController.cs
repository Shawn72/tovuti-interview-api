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
    [Route("api/SaleInvoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly Iinvoices _repo;

        public InvoiceController(Iinvoices repo) //create constructor
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllInvoices()
        {
            try
            {
                return Ok(await _repo.GetAllInvoices());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost("createinvoice")]
        public async Task<IActionResult> CreateCustomerDetails([FromBody] Invoices invoice)
        {
            if (invoice == null)
                return BadRequest();
            await _repo.CreateInvoice(invoice);
            return Ok();
        }

        [HttpGet("{InvoiceId}")]
        public IActionResult GetInvoice(Int64 id)
        {
            var invoice = _repo.GetInvoice(id);
            return Ok(invoice);
        }

        [HttpGet("{customerId}")]
        public IActionResult GetInvoiceByCustomer(Int64 id)
        {
            var invoices = _repo.GetInvoiceByCustomerId(id);
            return Ok(invoices);
        }

        [HttpPut("{InvoiceId}")]
        public async Task<IActionResult> UpdateInvoice(Int64 id, [FromBody] Invoices invoice)
        {
            // additional product and model validation checks
            var dbInvoice = _repo.GetInvoice(id);
            if (dbInvoice == null)
                return NotFound();
            await _repo.UpdateInvoice(invoice, dbInvoice);
            return Ok();
        }

        [HttpDelete("{InvoiceId}")]
        public async Task<IActionResult> DeleteInvoice(Int64 id)
        {
            var invoice = _repo.GetInvoice(id);
            if (invoice == null)
                return NotFound();
            await _repo.DeleteInvoice(invoice);
            return Ok();
        }
    }
}

