using System;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Domain.Events
{
    public class TransactionDeletedEvent : DomainEvent
    {
        public Guid AccessKey { get; }
        public string SymbolBeforeDeletion { get; }
        public TransactionType TypeBeforeDeletion { get; }
        public decimal QuantityBeforeDeletion { get; }

        public TransactionDeletedEvent(
            Guid accessKey, 
            string symbolBeforeDeletion,
            TransactionType typeBeforeDeletion,
            decimal quantityBeforeDeletion)
        {
            AccessKey = accessKey;
            SymbolBeforeDeletion = symbolBeforeDeletion;
            TypeBeforeDeletion = typeBeforeDeletion;
            QuantityBeforeDeletion = quantityBeforeDeletion;
        }
    }
}