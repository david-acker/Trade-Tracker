using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using Xunit;

namespace TradeTracker.Domain.UnitTests.Entities
{
    public class PositionTests
    {
        [Fact]
        public void Create_NewPosition_QuantityStartsAtZero()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            // Act
            var position = new Position(accessKey, symbol);

            // Assert
            position.Quantity.Should()
                .Be(Decimal.Zero);
        }

        [Fact]
        public void Create_NewPosition_ExposureTypeStartsAtNone()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            // Act
            var exposureType = position.Exposure;

            // Assert
            exposureType.Should()
                .Be("None");
        }

        [Fact]
        public void Create_NewPosition_IsClosedStartsAsTrue()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            // Act
            var position = new Position(accessKey, symbol);

            // Assert
            position.IsClosed.Should()
                .BeTrue();
        }

        [Fact]
        public void Attach_TransactionToExistingPosition_QuantityShiftsByAmountAttached()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var type = TransactionType.Buy;
            var quantity = (decimal)100;

            // Act
            position.Attach(type, quantity);

            // Assert
            position.Quantity.Should()
                .Be(quantity);
        }

        [Fact]
        public void Attach_TransactionToExistingPosition_SignOfQuantityIsIgnored()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var type = TransactionType.Buy;
            var quantity = (decimal)-100;

            // Act
            position.Attach(type, quantity);

            // Assert
            position.Quantity.Should()
                .Be(Math.Abs(quantity));
        }

        [Fact]
        public void Check_ExistingPositionWithNonZeroQuantity_IsClosedIsFalse()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var type = TransactionType.Buy;
            var quantity = (decimal)100;

            // Act
            position.Attach(type, quantity);

            // Assert
            position.IsClosed.Should()
                .BeFalse();
        }

        [Fact]
        public void Attach_BuyTransactionToExistingPosition_IncreasesLongPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var type = TransactionType.Buy;
            var quantity = (decimal)100;

            // Act
            position.Attach(type, quantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Long");
                
                position.Quantity.Should()
                    .Be(quantity);
            }
        }

        [Fact]
        public void Attach_SellTransactionToExistingPosition_DecreasesLongPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var initialLongQuantity = (decimal)100;
            position.Attach(TransactionType.Buy, initialLongQuantity);

            var sellQuantity = (decimal)50;

            // Act
            position.Attach(TransactionType.Sell, sellQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Long");

                position.Quantity.Should()
                    .Be(initialLongQuantity - sellQuantity);
            }
        }

        [Fact]
        public void Attach_SellTransactionToExistingPosition_IncreasesShortPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var type = TransactionType.Sell;
            var quantity = (decimal)100;

            // Act
            position.Attach(type, quantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Short");

                position.Quantity.Should()
                    .Be(quantity);
            }
        }

        [Fact]
        public void Attach_BuyTransactionToExistingPosition_DecreasesShortPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var initialShortQuantity = (decimal)100;
            position.Attach(TransactionType.Sell, initialShortQuantity);

            var buyQuantity = (decimal)50;

            // Act
            position.Attach(TransactionType.Buy, buyQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Short");

                position.Quantity.Should()
                    .Be(initialShortQuantity - buyQuantity);
            }
        }

        [Fact]
        public void Detach_BuyTransactionFromExistingPosition_DecreasesLongPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var initialLongQuantity = (decimal)100;
            position.Attach(TransactionType.Buy, initialLongQuantity);

            var buyQuantity = (decimal)50;

            // Act
            position.Detach(TransactionType.Buy, buyQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Long");
                
                position.Quantity.Should()
                    .Be(initialLongQuantity - buyQuantity);
            }
        }

        [Fact]
        public void Detach_SellTransactionFromExistingPosition_IncreasesLongPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var initialLongQuantity = (decimal)100;
            position.Attach(TransactionType.Buy, initialLongQuantity);

            var sellQuantity = (decimal)50;

            // Act
            position.Detach(TransactionType.Sell, sellQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Long");
                
                position.Quantity.Should()
                    .Be(initialLongQuantity + sellQuantity);
            }
        }

        [Fact]
        public void Detach_SellTransactionFromExistingPosition_DecreasesShortPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var initialShortQuantity = (decimal)100;
            position.Attach(TransactionType.Sell, initialShortQuantity);

            var sellQuantity = (decimal)50;

            // Act
            position.Detach(TransactionType.Sell, sellQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Short");

                position.Quantity.Should()
                    .Be(initialShortQuantity - sellQuantity);
            }
        }

        [Fact]
        public void Detach_BuyTransactionFromExistingPosition_IncreasesShortPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var initialShortQuantity = (decimal)100;
            position.Attach(TransactionType.Sell, initialShortQuantity);

            var buyQuantity = (decimal)50;

            // Act
            position.Detach(TransactionType.Buy, buyQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Short");

                position.Quantity.Should()
                    .Be(initialShortQuantity + buyQuantity);
            }
        }
    }
}