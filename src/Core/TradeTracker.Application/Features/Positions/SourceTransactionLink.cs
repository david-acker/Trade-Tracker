using System;

namespace TradeTracker.Application.Features.Positions
{
    public class SourceTransactionLink
    {
        public DateTime DateTime { get; set; }
        public decimal LinkedQuantity { get; set; }
        public decimal TradePrice { get; set; }
        public Guid TransactionId { get; set; }

        public SourceTransactionLink() { }
    }
}