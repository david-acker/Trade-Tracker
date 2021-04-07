using System;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;

namespace TradeTracker.Application.Features.Positions
{
    public class FullSourceTransactionLink
    {
        public Guid TransactionId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Quantity { get; set; }
        public decimal TradePrice { get; set; }
        public TransactionForReturnWithLinksDto Transaction { get; set; }

        public FullSourceTransactionLink() { }

        public FullSourceTransactionLink(
            SourceTransactionLink sourceLink, 
            TransactionForReturnWithLinksDto transactionWithLinks)
        {
            TransactionId = sourceLink.TransactionId;
            DateTime = sourceLink.DateTime;
            Quantity = sourceLink.Quantity;
            TradePrice = sourceLink.TradePrice;

            Transaction = transactionWithLinks;
        }
    }
}