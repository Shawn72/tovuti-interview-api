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
    [Route("api/saletranx")]
    public class SaleTransactionsController : ControllerBase
    {
        private readonly ISalesTransactions _repo;

        public SaleTransactionsController(ISalesTransactions repo) //create constructor
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSaleTransactions()
        {
            try
            {
                return Ok(await _repo.GetAllSalesTransactions());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost("createsaletranx")]
        public async Task<IActionResult> CreateSaleTransaction([FromBody] SalesTransactions saletrx)
        {
            if (saletrx == null)
                return BadRequest();
            await _repo.CreateSalesTransaction(saletrx);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleTransaction(Int64 id)
        {
            var sale = _repo.GetSalesTransaction(id);
            return Ok(sale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSaleTransaction(Int64 id, [FromBody] SalesTransactions saletrx )
        {
            // additional product and model validation checks
            var dbSaletrx = _repo.GetSalesTransaction(id);
            if (dbSaletrx == null)
                return NotFound();
            await _repo.UpdateSalesTransaction(saletrx, dbSaletrx);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleTransaction(Int64 id)
        {
            var saletrx = _repo.GetSalesTransaction(id);
            if (saletrx == null)
                return NotFound();
            await _repo.DeleteSalesTransaction(saletrx);
            return Ok();
        }
    }
}
