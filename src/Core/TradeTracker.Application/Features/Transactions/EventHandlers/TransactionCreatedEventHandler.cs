using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using TradeTracker.Application.Common.Interfaces.Infrastructure;
using TradeTracker.Application.Common.Models;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.EventHandlers
{
    public class TransactionCreatedEventHandler : INotificationHandler<DomainEventNotification<TransactionCreatedEvent>>
    {
        private readonly ILogger<TransactionCreatedEventHandler> _logger;
        private readonly IPositionTrackingService _positionTrackingService;

        public TransactionCreatedEventHandler(
            ILogger<TransactionCreatedEventHandler> logger,
            IPositionTrackingService positionTrackingService)
        {
            _logger = logger;
            _positionTrackingService = positionTrackingService;
        }

        public Task Handle(DomainEventNotification<TransactionCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation($"TradeTracker Domain Event: {domainEvent.GetType().Name} received.");

            _positionTrackingService.RefreshAfterCreation(
                domainEvent.TransactionId);
        
            return Task.CompletedTask;
        }
    }
}