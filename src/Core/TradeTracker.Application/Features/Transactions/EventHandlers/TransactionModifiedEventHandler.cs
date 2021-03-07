using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Models;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.EventHandlers
{
    public class TransactionModifiedEventHandler : INotificationHandler<DomainEventNotification<TransactionModifiedEvent>>
    {
        private readonly ILogger<TransactionModifiedEventHandler> _logger;
        private readonly IPositionTrackingService _positionTrackingService;

        public TransactionModifiedEventHandler(
            ILogger<TransactionModifiedEventHandler> logger,
            IPositionTrackingService positionTrackingService)
        {
            _logger = logger;
            _positionTrackingService = positionTrackingService;
        }

        public Task Handle(DomainEventNotification<TransactionModifiedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation($"TradeTracker Domain Event: {domainEvent.GetType().Name} received.");

            _positionTrackingService.RefreshAfterModification(
                accessKey: domainEvent.AccessKey, 
                transactionId: domainEvent.TransactionId, 
                symbolBeforeModification: domainEvent.SymbolBeforeModification,
                typeBeforeModification: domainEvent.TypeBeforeModification,
                quantityBeforeModification: domainEvent.QuantityBeforeModification);
        
            return Task.CompletedTask;
        }
    }
}