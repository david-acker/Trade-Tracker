using System.Collections.Generic;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class PagedTransactionsDto 
    {
        public IEnumerable<TransactionForReturnDto> Items { get; set; }
    }
}