using MediatR;
using TradeTracker.Domain.Common;

namespace TradeTracker.Application.Models
{
    public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : DomainEvent
    {
        public TDomainEvent DomainEvent { get; }

        public DomainEventNotification(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}