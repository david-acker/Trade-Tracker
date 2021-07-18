using System;
using System.Collections.Generic;

namespace TradeTracker.Api.DTOs.Transaction
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public string Symbol { get; set; }
        public DateTime TradeDate { get; set; }
        public decimal TradePrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Notional { get; set; }
    }

    public class LinkedTransactionDto
    {
        public TransactionDto Transaction { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }

    public class TransactionInputDto
    {
        public string Type { get; set; }
        public string Symbol { get; set; }
        public DateTime TradeDate { get; set; }
        public decimal TradePrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Notional { get; set; }
    }
}
