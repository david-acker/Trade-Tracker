using System.Collections.Generic;
using TradeTracker.Application.Common.Models.Resources.Responses;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class PagedTransactionsBase
    {
        public PaginationMetadata Metadata { get; set; }
        
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public IEnumerable<TransactionForReturn> Items { get; set; }
    }
}