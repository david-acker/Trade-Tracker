using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Models.Resources.Parameters.Transactions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Common.Interfaces.Persistence.Transactions
{
    public interface ITransactionRepository : 
        IAsyncRepository<Transaction, PagedTransactionsResourceParameters, UnpagedTransactionsResourceParameters>
    {
        Task<IEnumerable<Transaction>> GetTransactionCollectionByIdsAsync(
            IEnumerable<Guid> ids,
            Guid accessKey);

        HashSet<string> GetSetOfSymbolsForAllTransactionsByUser(
            Guid accessKey);
    }
}
