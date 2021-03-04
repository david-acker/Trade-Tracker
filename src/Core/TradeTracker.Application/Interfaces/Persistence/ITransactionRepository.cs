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
        Task<PagedList<Transaction>> GetPagedTransactionsList(GetPagedTransactionsResourceParameters parameters);

        Task<IEnumerable<Transaction>> GetTransactionCollectionByIds(string accessKey, IEnumerable<Guid> ids);

        Task<IEnumerable<Transaction>> GetAllTransactionsForSymbol(string access, string symbol);
    }
}
