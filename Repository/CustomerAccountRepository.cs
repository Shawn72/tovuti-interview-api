using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TovutiAPI.DBContexts;
using TovutiAPI.Entities;
using TovutiAPI.Interface;

namespace TovutiAPI.Repository
{
    public class CustomerAccountRepository: ICustomerAccounts
    {
        private readonly DatabaseContext _context;

        public CustomerAccountRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateCustomerAccount(CustomerAccounts cstmAccount)
        {
            _context.Add(cstmAccount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAccount(CustomerAccounts cstmAccount)
        {
            _context.Remove(cstmAccount);
            await _context.SaveChangesAsync();
        }    

        //get customer accounts filter by Id
        public async Task<IEnumerable<CustomerAccounts>> GetAccountsByCustomerId(long id)
        {            //get whole list            
            return await _context.customer_accounts.Where(o=>o.customer_id.Equals(id)).ToListAsync();
        }

        public async Task<IEnumerable<CustomerAccounts>> GetAllCustomerAccounts()
        {
            //get whole list 
            return await _context.customer_accounts.ToListAsync();
        }
        
        public CustomerAccounts GetCustomerAccount(long id) =>
            _context.customer_accounts.FirstOrDefault(p => p.id.Equals(id));

        public async Task UpdateCustomerAccount(CustomerAccounts cstmAccount, CustomerAccounts dBcstmAccount)
        {
            dBcstmAccount.account_balance = dBcstmAccount.account_balance - (cstmAccount.account_balance);
           // dBcstmAccount.active = cstmAccount.active;
            await _context.SaveChangesAsync();
        }
    }
}
