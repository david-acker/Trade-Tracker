using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Models.Resources.Parameters.Transactions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Common.Interfaces.Persistence.Transactions
{
    public interface IAuthenticatedTransactionRepository : 
        IAuthenticatedAsyncRepository<Transaction, PagedTransactionsResourceParameters, UnpagedTransactionsResourceParameters>
    {
        Task<IEnumerable<Transaction>> GetTransactionCollectionByIdsAsync(
            IEnumerable<Guid> ids);

        HashSet<string> GetSetOfSymbolsForAllTransactionsByUser();
    }
}