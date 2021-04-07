using System;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Entities;

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

        public TransactionCreatedEvent(Transaction transaction)
        {
            AccessKey = transaction.AccessKey;
            TransactionId = transaction.Id;
        }
    }
}