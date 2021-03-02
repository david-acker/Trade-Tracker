using System;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Transactions
{
    public class TransactionForCreationDto
    {
        public string AccessKey { get; set; }
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
        public string TransactionType { get; set; }
        public decimal Quantity { get; set; }
        public decimal Notional { get; set; }
        public decimal? TradePrice { get; set; }
        public List<string> Tags { get; set; }
    }
}
