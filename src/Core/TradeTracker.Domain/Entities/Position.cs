using System;
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

        public string Symbol { get; set; }

        public ExposureType Exposure { get; set; } = ExposureType.None;

        public decimal Quantity { get; set; } = decimal.Zero; 
    }
}