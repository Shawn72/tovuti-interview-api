using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TovutiAPI.Entities;
using TovutiAPI.Models;

namespace TovutiAPI.Interface
{
    public interface IinvoicePayment
    {
        Task CreatePayment(InvoicePayments payments);      
        Task<IEnumerable<JointPaymentModel>> GetPaymentsByCustomerId(Int64 customerId);
        Task<IEnumerable<InvoicePayments>> GetAllPayments();       
        Task DeletePayment(InvoicePayments payments);
    }
}
