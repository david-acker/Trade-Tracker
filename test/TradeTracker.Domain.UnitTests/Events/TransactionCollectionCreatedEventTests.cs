using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Events;
using Xunit;

namespace TradeTracker.Domain.UnitTests.Events
{
    public class TransactionCollectionCreatedEventTests
    {
        [Fact]
        public void Create_NewEvent_TransactionMapGroupedByUniqueSymbols()
        {
            // Arrange
            IEnumerable<Transaction> transactionCollection = new List<Transaction>()
            {
                new Transaction()
                {
                    AccessKey = Guid.Parse("fc0bd83d-8bc2-49a6-a6ab-b94c99ad7b1a"),
                    DateTime = new DateTime(2020, 1, 1),
                    Symbol = "A",
                    Type = TransactionType.Buy,
                    Quantity = 5,
                    Notional = 10,
                    TradePrice = 2
                },
                new Transaction()
                {
                    AccessKey = Guid.Parse("fc0bd83d-8bc2-49a6-a6ab-b94c99ad7b1a"),
                    DateTime = new DateTime(2020, 1, 2),
                    Symbol = "B",
                    Type = TransactionType.Sell,
                    Quantity = 2,
                    Notional = 22,
                    TradePrice = 11
                },
                new Transaction()
                {
                    AccessKey = Guid.Parse("fc0bd83d-8bc2-49a6-a6ab-b94c99ad7b1a"),
                    DateTime = new DateTime(2020, 1, 3),
                    Symbol = "A",
                    Type = TransactionType.Sell,
                    Quantity = 4,
                    Notional = 12,
                    TradePrice = 3
                }
            };

            // Act
            var domainEvent = new TransactionCollectionCreatedEvent(transactionCollection);

            // Assert
            var keys = new List<string>(domainEvent.TransactionMap.Keys);

            keys.Should()
                .HaveCount(k => k == 2);
        }
    }
}