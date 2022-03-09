using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TovutiAPI.Entities;

namespace TovutiAPI.Interface
{
    public interface ISalesTransactions
    {
        Task CreateSalesTransaction(SalesTransactions salesTransactions);
        SalesTransactions GetSalesTransaction(Int64 id);
        Task<IEnumerable<SalesTransactions>> GetAllSalesTransactions();
        Task UpdateSalesTransaction(SalesTransactions salesTransactions, SalesTransactions dBsalesTransactions);
        Task DeleteSalesTransaction(SalesTransactions salesTransactions);
    }
}
