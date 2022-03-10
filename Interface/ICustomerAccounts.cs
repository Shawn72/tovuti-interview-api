using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TovutiAPI.Entities;

namespace TovutiAPI.Interface
{
    public interface ICustomerAccounts
    {
        Task CreateCustomerAccount(CustomerAccounts cstmAccount);
        CustomerAccounts GetCustomerAccount(Int64 id);
        Task<IEnumerable<CustomerAccounts>> GetAllCustomerAccounts();
        Task UpdateCustomerAccount(CustomerAccounts cstmAccount, CustomerAccounts dBcstmAccount);
        Task DeleteCustomerAccount(CustomerAccounts cstmAccount);
        Task<IEnumerable<CustomerAccounts>> GetAccountsByCustomerId(Int64 customerId);
    }
}
