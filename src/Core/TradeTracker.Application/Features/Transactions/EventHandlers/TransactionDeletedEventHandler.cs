using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using TradeTracker.Application.Common.Interfaces.Infrastructure;
using TradeTracker.Application.Common.Models;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.EventHandlers
{
    public class TransactionDeletedEventHandler : INotificationHandler<DomainEventNotification<TransactionDeletedEvent>>
    {
        private readonly ILogger<TransactionDeletedEventHandler> _logger;
        private readonly IPositionTrackingService _positionTrackingService;

        public TransactionDeletedEventHandler(
            ILogger<TransactionDeletedEventHandler> logger,
            IPositionTrackingService positionTrackingService)
        {
            _logger = logger;
            _positionTrackingService = positionTrackingService;
        }

        public Task Handle(DomainEventNotification<TransactionDeletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation($"TradeTracker Domain Event: {domainEvent.GetType().Name} received.");

            _positionTrackingService.RefreshAfterDeletion(
                domainEvent.SymbolBeforeDeletion,
                domainEvent.TypeBeforeDeletion,
                domainEvent.QuantityBeforeDeletion);
        
            return Task.CompletedTask;
        }
    }
}