using System;
using System.ComponentModel.DataAnnotations;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Domain.Entities
{
    public class Transaction : AuditableEntity
    {
        [Key]
        public Guid TransactionId { get; set; }
        public string AccessTag { get; set; }
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
        public TransactionType TransactionType { get; set; } = TransactionType.NotSpecified;
        public decimal Quantity { get; set; }
        public decimal Notional { get; set; }
        public decimal? TradePrice { get; set; }
    }
}