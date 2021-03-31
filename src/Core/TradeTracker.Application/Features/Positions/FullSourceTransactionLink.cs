using System;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;

namespace TradeTracker.Application.Features.Positions
{
    public class FullSourceTransactionLink
    {
        public DateTime DateTime { get; set; }
        public decimal LinkedQuantity { get; set; }
        public decimal TradePrice { get; set; }
        public TransactionForReturnWithLinksDto Transaction { get; set; }
    }
}