using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TovutiAPI.DBContexts;
using TovutiAPI.Entities;
using TovutiAPI.Interface;

namespace TovutiAPI.Repository
{
    public class CustomerDetailsRepository : ICustomerDetails
    {

        private readonly DatabaseContext _context;

        public CustomerDetailsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateCustomerDetails(CustomerDetails customerDetails)
        {
            _context.Add(customerDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerDetail(CustomerDetails customerDetails)
        {
            _context.Remove(customerDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerDetails>> GetAllCustomerDetails()
        {
            //get whole list 
            return await _context.customer_details.ToListAsync();
        }

        public CustomerDetails GetCustomerDetail(long id) =>
            _context.customer_details.FirstOrDefault(p => p.id.Equals(id));

        public async Task UpdateCustomerDetail(CustomerDetails customerDetails, CustomerDetails dBcustomerDetails)
        {
            dBcustomerDetails.payment_terms = customerDetails.payment_terms;
            dBcustomerDetails.credit_limit = customerDetails.credit_limit;
            await _context.SaveChangesAsync();
        }
    }
}
