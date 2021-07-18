using Autofac.Extras.Moq;
using Moq;
using System;
using System.Linq;
using TradeTracker.Business.Services;
using TradeTracker.Core.DomainModels.Transaction;
using Xunit;

namespace TradeTracker.Business.Test.Services
{
    public class TransactionServiceTests
    {
        [Fact]
        public void ItWillValidateTransaction()
        {
            var transaction = new TransactionDomainModel
            {
                Symbol = "ABC",
                TradeDate = new DateTime(year: 2020, month: 1, day: 1),
                TradePrice = 100,
                Quantity = 1,
                Notional = 100
            };

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDateTimeService>()
                    .Setup(x => x.HasDateTimeAlreadyOccurred(It.IsAny<DateTime>()))
                    .Returns(true);

                var service = mock.Create<TransactionService>();

                var result = service.ValidateTransaction(transaction);

                Assert.NotNull(result);
                Assert.Empty(result);
                Assert.True(result.IsValid);
            }
        }

        [Fact]
        public void ItWillInvalidateTransaction()
        {
            var transaction = new TransactionDomainModel
            {
                Symbol = string.Empty,
                TradeDate = new DateTime(year: 2020, month: 1, day: 1),
                TradePrice = -1,
                Quantity = 0,
                Notional = 0
            };

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDateTimeService>()
                    .Setup(x => x.HasDateTimeAlreadyOccurred(It.IsAny<DateTime>()))
                    .Returns(false);

                var service = mock.Create<TransactionService>();

                var result = service.ValidateTransaction(transaction);

                Assert.NotNull(result);
                Assert.Equal(5, result.Count());
                Assert.False(result.IsValid);
            }
        }

        [Fact]
        public void ItWillValidateTransactionFilterModel()
        {
            var filterModel = new TransactionFilterDomainModel
            {
                Page = 1,
                PageSize = 25,
                StartDate = new DateTime(year: 2020, month: 1, day: 1),
                EndDate = new DateTime(year: 2021, month: 1, day: 1),
                Symbol = "ABC",
                TransactionType = 'B',
                OrderByField = "TradeDate",
                OrderByDirection = 'A'
            };

            using (var mock = AutoMock.GetLoose())
            {
                var service = mock.Create<TransactionService>();

                var result = service.ValidateTransactionFilterModel(filterModel);

                Assert.NotNull(result);
                Assert.Empty(result);
                Assert.True(result.IsValid);
            }
        }

        [Fact]
        public void ItWillInvalidateTransactionFilterModel()
        {
            var filterModel = new TransactionFilterDomainModel
            {
                Page = -1,
                PageSize = -25,
                StartDate = new DateTime(year: 2021, month: 1, day: 1),
                EndDate = new DateTime(year: 2020, month: 1, day: 1),
                Symbol = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                TransactionType = '0',
                OrderByField = "FakeField",
                OrderByDirection = '0'
            };

            using (var mock = AutoMock.GetLoose())
            {
                var service = mock.Create<TransactionService>();

                var result = service.ValidateTransactionFilterModel(filterModel);

                Assert.NotNull(result);
                Assert.Equal(7, result.Count());
                Assert.False(result.IsValid);
            }
        }
    }
}
