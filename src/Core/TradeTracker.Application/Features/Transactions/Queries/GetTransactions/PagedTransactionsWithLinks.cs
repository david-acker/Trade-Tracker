using System.Collections.Generic;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class PagedTransactionsWithLinks 
    {
        public PaginationMetadata Metadata { get; set; }

        public IEnumerable<TransactionForReturnWithLinks> Items { get; set; }

        public IEnumerable<Link> Links { get; set; }
    }
}