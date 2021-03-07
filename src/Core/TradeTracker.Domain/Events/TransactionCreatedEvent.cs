using System;
using TradeTracker.Domain.Common;

namespace TradeTracker.Domain.Events
{
    public class TransactionCreatedEvent : DomainEvent
    {
        public Guid AccessKey { get; }
        public Guid TransactionId { get; }

        public TransactionCreatedEvent(Guid accessKey, Guid transactionId)
        {
            AccessKey = accessKey;
            TransactionId = transactionId;
        }
    }
}