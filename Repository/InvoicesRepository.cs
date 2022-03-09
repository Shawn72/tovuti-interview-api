using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TovutiAPI.DBContexts;
using TovutiAPI.Entities;
using TovutiAPI.Interface;

namespace TovutiAPI.Repository
{
    public class InvoicesRepository: Iinvoices
    {
        private readonly DatabaseContext _context;

        public InvoicesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateInvoice(Invoices invoices)
        {
            _context.Add(invoices);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvoice(Invoices invoices)
        {
            _context.Remove(invoices);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Invoices>> GetAllInvoices()
        {
            //get whole list 
            return await _context.invoices.ToListAsync();
        }

        public Invoices GetInvoice(long id) =>
            _context.invoices.FirstOrDefault(p => p.id.Equals(id));

     

        public async Task UpdateInvoice(Invoices invoices, Invoices dBinvoices)
        {
            dBinvoices.payment_terms = invoices.payment_terms;
            dBinvoices.transaction_date = invoices.transaction_date;
            dBinvoices.amount = invoices.amount;
            dBinvoices.due_date = invoices.due_date;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Invoices>> GetInvoiceByCustomerId(long id)
        {
            //get whole list 
            return await _context.invoices.Where(r=>r.customer_id == id).ToListAsync();
        }
    }
}
