using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Interfaces.Persistence
{
    public interface ITransactionRepository : IAsyncRepository<Transaction>
    {
        Task<PagedList<Transaction>> GetPagedTransactionsListAsync(GetPagedTransactionsResourceParameters parameters);

        Task<IEnumerable<Transaction>> GetTransactionCollectionByIdsAsync(Guid AccessKey, IEnumerable<Guid> ids);

        Task<IEnumerable<Transaction>> GetAllTransactionsForSymbolAsync(Guid AccessKey, string symbol);

        HashSet<string> GetSetOfSymbolsForAllTransactionsByUser(Guid accessKey);
    }
}
