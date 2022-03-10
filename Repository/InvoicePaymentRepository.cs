using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TovutiAPI.DBContexts;
using TovutiAPI.Entities;
using TovutiAPI.Interface;
using TovutiAPI.Models;

namespace TovutiAPI.Repository
{
    public class InvoicePaymentRepository:IinvoicePayment
    {
        private readonly DatabaseContext _context;

        public InvoicePaymentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreatePayment(InvoicePayments payments)
        {
            _context.Add(payments);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePayment(InvoicePayments payments)
        {
            _context.Remove(payments);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InvoicePayments>> GetAllPayments()
        {         
            //get whole list 
            return await _context.invoice_payments.ToListAsync();
        }

        public async Task <IEnumerable<JointPaymentModel>> GetPaymentsByCustomerId(long customerId)
        {
            //do EF Core joins for 3 related tables //just like MySQl joins
            var paym =  await (from p in _context.invoice_payments
                        join i in _context.invoices on p.invc_id equals i.id                         
                        join c in _context.customer_details on i.customer_id equals c.id 
                        where c.id == customerId
                        select new JointPaymentModel
                        {
                            custmrid = c.id,
                            national_id = c.id_number,
                            creditlimit = c.credit_limit,
                            trx_id =i.sale_trx_id,
                            duedate= i.due_date,
                            amountgiven = i.amount,
                            amtpaid = p.amount_paid,
                            paydate = p.date_paid,
                            fullypaid =i.fully_paid
                        }).ToListAsync();
            return paym;

        }
    }
}
