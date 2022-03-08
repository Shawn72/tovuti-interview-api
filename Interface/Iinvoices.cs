using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TovutiAPI.Entities;

namespace TovutiAPI.Interface
{
    public interface Iinvoices
    {
        Task CreateInvoice(Invoices invoices);
        Invoices GetInvoice(Int64 id);
        Task<IEnumerable<Invoices>> GetAllInvoices();
        Task UpdateInvoice(Invoices invoices, Invoices dBinvoices);
        Task DeleteInvoice(Invoices invoices);
    }
}
