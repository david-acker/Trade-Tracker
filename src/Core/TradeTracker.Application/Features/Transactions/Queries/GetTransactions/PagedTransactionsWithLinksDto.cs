using System.Collections.Generic;
using TradeTracker.Api.Models.Pagination;
using TradeTracker.Application.Models.Navigation;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class PagedTransactionsWithLinksDto 
    {
        public PaginationMetadata Metadata { get; set; }

        public IEnumerable<TransactionForReturnWithLinksDto> Items { get; set; }

        public IEnumerable<LinkDto> Links { get; set; }
    }
}