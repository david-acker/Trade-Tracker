using System;
using System.ComponentModel.DataAnnotations;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Interfaces;

namespace TradeTracker.Domain.Entities
{
    public class Position : AuditableEntity, IAuthorizableEntity
    {
        public Position() { }
        public Position(Guid accessKey, string symbol)
        {
            AccessKey = accessKey;
            Symbol = symbol;
        }

        [Key]
        public Guid PositionId { get; set; }

        public Guid AccessKey { get; set; }

        public string Symbol { get; set; }

        public ExposureType Exposure { get; set; } = ExposureType.None;

        public decimal Quantity { get; set; } = Decimal.Zero;
    }
}