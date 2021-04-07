using System;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Domain.Events
{
    public class TransactionModifiedEvent : DomainEvent
    {
        public Guid AccessKey { get; }
        public Guid TransactionId { get; }
        public string SymbolBeforeModification { get; }
        public TransactionType TypeBeforeModification { get; }
        public decimal QuantityBeforeModification { get; }

        public TransactionModifiedEvent(
            Guid accessKey, 
            Guid transactionId, 
            string symbolBeforeModification, 
            TransactionType typeBeforeModification,
            decimal quantityBeforeModification)
        {
            AccessKey = accessKey;
            TransactionId = transactionId;
            SymbolBeforeModification = symbolBeforeModification;
            TypeBeforeModification = typeBeforeModification;
            QuantityBeforeModification = quantityBeforeModification;
        }

        public TransactionModifiedEvent(Transaction originalTransaction)
        {
            AccessKey = originalTransaction.AccessKey;
            TransactionId = originalTransaction.Id;
            SymbolBeforeModification = originalTransaction.Symbol;
            TypeBeforeModification = originalTransaction.Type;
            QuantityBeforeModification = originalTransaction.Quantity;
        }
    }
}