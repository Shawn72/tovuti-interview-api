using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TovutiAPI.DBContexts;
using TovutiAPI.Entities;
using TovutiAPI.Interface;

namespace TovutiAPI.Repository
{
    public class SalesTransactionsRepository:ISalesTransactions
    {
        private readonly DatabaseContext _context;
        public SalesTransactionsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateSalesTransaction(SalesTransactions salesTransactions)
        {
            _context.Add(salesTransactions);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSalesTransaction(SalesTransactions salesTransactions)
        {
            _context.Remove(salesTransactions);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SalesTransactions>> GetAllSalesTransactions()
        {
            //get whole list 
            return await _context.sale_transactions.ToListAsync();
        }

        public SalesTransactions GetSalesTransaction(long id) =>
            _context.sale_transactions.FirstOrDefault(p => p.id.Equals(id));

        public async Task UpdateSalesTransaction(SalesTransactions salesTransactions, SalesTransactions dBsalesTransactions)
        {
            dBsalesTransactions.product_amount = salesTransactions.product_amount;
            dBsalesTransactions.payment_mode = salesTransactions.payment_mode;
            dBsalesTransactions.price = salesTransactions.price;
            dBsalesTransactions.transaction_date = salesTransactions.transaction_date;
            dBsalesTransactions.unit_of_measurement = salesTransactions.unit_of_measurement;
            await _context.SaveChangesAsync();
        }
    
    }
}
