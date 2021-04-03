using System.Collections.Generic;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class PagedTransactionsWithLinksDto 
    {
        public PaginationMetadata Metadata { get; set; }

        public IEnumerable<TransactionForReturnWithLinksDto> Items { get; set; }

        public IEnumerable<LinkDto> Links { get; set; }
    }
}