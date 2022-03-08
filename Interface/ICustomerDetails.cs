using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TovutiAPI.Entities;

namespace TovutiAPI.Interface
{
    public interface ICustomerDetails
    {
        Task CreateCustomerDetails(CustomerDetails customerDetails);
        CustomerDetails GetCustomerDetail(Int64 id);
        Task<IEnumerable<CustomerDetails>> GetAllCustomerDetails();
        Task UpdateCustomerDetail(CustomerDetails customerDetails, CustomerDetails dBcustomerDetails);
        Task DeleteCustomerDetail(CustomerDetails customerDetails);
    }
}
