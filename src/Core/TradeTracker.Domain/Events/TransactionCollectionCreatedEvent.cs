using System;
using System.Collections.Generic;
using System.Linq;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Domain.Events
{
    public class TransactionCollectionCreatedEvent : DomainEvent
    {
        public Guid AccessKey { get; }
        public Dictionary<string, List<Guid>> TransactionMap { get; }

        public TransactionCollectionCreatedEvent(IEnumerable<Transaction> transactionCollection)
        {
            AccessKey = transactionCollection.First().AccessKey;
            TransactionMap = CreateTransactionMap(transactionCollection);
        }

        private Dictionary<string, List<Guid>> CreateTransactionMap(IEnumerable<Transaction> transactionCollection)
        {
            return transactionCollection
                .GroupBy(t => t.Symbol)
                .ToDictionary(
                    t => t.Key, 
                    t => t.Select(i => i.TransactionId)
                          .Distinct()
                          .ToList());
        }
    }
}