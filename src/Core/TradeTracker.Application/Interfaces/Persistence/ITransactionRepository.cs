using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactionsList;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Interfaces.Persistence
{
    public interface ITransactionRepository : IAsyncRepository<Transaction>
    {
        Task<PagedList<Transaction>> GetPagedTransactionsList(GetPagedTransactionsListResourceParameters parameters);

        Task<IEnumerable<Transaction>> GetTransactionCollectionByIds(string accessTag, IEnumerable<Guid> ids);
    }
}
