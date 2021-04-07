using System;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;

namespace TradeTracker.Application.Features.Positions
{
    public class FullSourceRelation
    {
        public Guid TransactionId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Quantity { get; set; }
        public decimal TradePrice { get; set; }
        public TransactionForReturnWithLinks Transaction { get; set; }

        public FullSourceRelation() { }

        public FullSourceRelation(
            SourceRelation sourceRelation, 
            TransactionForReturnWithLinks transactionWithLinks)
        {
            TransactionId = sourceRelation.TransactionId;
            DateTime = sourceRelation.DateTime;
            Quantity = sourceRelation.Quantity;
            TradePrice = sourceRelation.TradePrice;

            Transaction = transactionWithLinks;
        }
    }
}