using System.Threading.Tasks;
using TradeTracker.Domain.Common;

namespace TradeTracker.Application.Common.Interfaces.Infrastructure
{
    public interface IDomainEventService
    {
        Task Publish(
            DomainEvent domainEvent);
    }
}