using System.Collections.Generic;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class PagedTransactions
    {
        public IEnumerable<TransactionForReturn> Items { get; set; }
    }
}