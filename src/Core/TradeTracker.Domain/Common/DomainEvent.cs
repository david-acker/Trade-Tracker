using System;

namespace TradeTracker.Domain.Common
{
    public abstract class DomainEvent
    {
        public bool IsPublished { get; set; }
        public DateTime DateOccurred { get; init; }

        protected DomainEvent()
        {
            DateOccurred = DateTime.UtcNow;
        }
    }
}