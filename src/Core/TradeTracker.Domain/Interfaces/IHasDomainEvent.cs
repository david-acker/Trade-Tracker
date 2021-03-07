using System.Collections.Generic;
using TradeTracker.Domain.Common;

namespace TradeTracker.Domain.Interfaces
{
    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }
}