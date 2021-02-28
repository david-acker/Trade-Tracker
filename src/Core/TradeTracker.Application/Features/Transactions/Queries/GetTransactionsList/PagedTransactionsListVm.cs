using System.Collections.Generic;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionsList
{
    public class PagedTransactionsListVm 
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public IEnumerable<TransactionDto> Items { get; set; }
    }
}