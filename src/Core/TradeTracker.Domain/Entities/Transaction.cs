using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Interfaces;

namespace TradeTracker.Domain.Entities
{
    public class Transaction : AuditableEntity, IAuthorizableEntity, IHasDomainEvent
    {
        [Key]
        public Guid TransactionId { get; set; } = Guid.NewGuid();

        public Guid AccessKey { get; set; }

        public DateTime DateTime { get; set; }

        public string Symbol { get; set; }

        public TransactionType Type { get; set; } = TransactionType.NotSpecified;

        public decimal Quantity { get; set; }

        public decimal Notional { get; set; }

        public decimal TradePrice { get; set; }

        [NotMapped]
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}