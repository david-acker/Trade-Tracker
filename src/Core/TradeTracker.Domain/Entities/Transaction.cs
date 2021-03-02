using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Domain.Entities
{
    public class Transaction : AuditableEntity
    {
        [Key]
        public Guid TransactionId { get; set; }
        public string AccessKey { get; set; }
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
        public TransactionType TransactionType { get; set; } = TransactionType.NotSpecified;
        public decimal Quantity { get; set; }
        public decimal Notional { get; set; }
        public decimal? TradePrice { get; set; }
        [NotMapped]
        public List<string> Tags { get; set; } = new List<string>();
    }
}