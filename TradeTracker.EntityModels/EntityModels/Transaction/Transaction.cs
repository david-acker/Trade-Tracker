using System;

namespace TradeTracker.EntityModels.Models.Transaction
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string AccessKey { get; set; }
        public string Symbol { get; set; }
        public DateTime TradeDate { get; set; }
        public decimal TradePrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Notional { get; set; }
    }
}
