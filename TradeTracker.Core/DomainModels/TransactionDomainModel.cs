using System;

namespace TradeTracker.Core.DomainModels
{
    public class TransactionDomainModel
    {
        public int TransactionId { get; set; }
        public string Symbol { get; set; }
        public DateTime TradeDate { get; set; }
        public decimal TradePrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Notional { get; set; }
    }

    public class TransactionInputDomainModel
    {
        public string Symbol { get; set; }
        public DateTime TradeDate { get; set; }
        public decimal TradePrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Notional { get; set; }
    }
}
