using System;
using System.Collections.Generic;

namespace TradeTracker.Core.DomainModels.Transaction
{
    public class TransactionDomainModel
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
