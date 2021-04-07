using System.Collections.Generic;
using FluentAssertions;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Events;
using Xunit;

namespace TradeTracker.Domain.UnitTests.Events
{
    public class TransactionCollectionCreatedEventTests
    {
        [Theory]
        [MemberData(nameof(TransactionCollectionTestData.TestData),
            MemberType = typeof(TransactionCollectionTestData))]
        public void Create_NewEvent_TransactionMapGroupedByUniqueSymbols(
            IEnumerable<Transaction> transactionCollection)
        {
            // Act
            var domainEvent = new TransactionCollectionCreatedEvent(transactionCollection);

            // Assert
            var keys = new List<string>(domainEvent.TransactionMap.Keys);

            keys.Should()
                .HaveCount(k => k == 2);
        }
    }
}