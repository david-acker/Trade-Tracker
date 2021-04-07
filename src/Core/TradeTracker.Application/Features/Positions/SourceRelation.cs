using System;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions
{
    public class SourceRelation
    {
         public Guid TransactionId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TradePrice { get; set; }
        public decimal Quantity { get; set; }
       

        public SourceRelation(Transaction transaction, decimal quantity)
        {
            TransactionId = transaction.Id;
            DateTime = transaction.DateTime;
            TradePrice = transaction.TradePrice;
    
            Quantity = quantity;
        }
    }
}