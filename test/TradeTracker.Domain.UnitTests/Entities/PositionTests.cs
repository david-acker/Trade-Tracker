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

            var type = TransactionType.BuyToOpen;
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

            var type = TransactionType.BuyToOpen;
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

            var type = TransactionType.BuyToOpen;
            var quantity = (decimal)100;

            // Act
            position.Attach(type, quantity);

            // Assert
            position.IsClosed.Should()
                .BeFalse();
        }

        [Fact]
        public void Attach_BuyToOpenTransactionToExistingPosition_IncreasesLongPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var type = TransactionType.BuyToOpen;
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
        public void Attach_SellToCloseTransactionExistingPosition_DecreasesLongPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var initialLongQuantity = (decimal)100;
            position.Attach(TransactionType.BuyToOpen, initialLongQuantity);

            var sellToCloseQuantity = (decimal)50;

            // Act
            position.Attach(TransactionType.SellToClose, sellToCloseQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Long");

                position.Quantity.Should()
                    .Be(initialLongQuantity - sellToCloseQuantity);
            }
        }

        [Fact]
        public void Attach_SellToOpenTransactionExistingPosition_IncreasesShortPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var type = TransactionType.SellToOpen;
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
        public void Attach_BuyToCloseTransactionExistingPosition_DecreasesShortPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var initialShortQuantity = (decimal)100;
            position.Attach(TransactionType.SellToOpen, initialShortQuantity);

            var buyToCloseQuantity = (decimal)50;

            // Act
            position.Attach(TransactionType.BuyToClose, buyToCloseQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Short");

                position.Quantity.Should()
                    .Be(initialShortQuantity - buyToCloseQuantity);
            }
        }

        [Fact]
        public void Detach_BuyToOpenTransactionFromExistingPosition_DecreasesLongPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var initialLongQuantity = (decimal)100;
            position.Attach(TransactionType.BuyToOpen, initialLongQuantity);

            var buyToOpenQuantity = (decimal)50;

            // Act
            position.Detach(TransactionType.BuyToOpen, buyToOpenQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Long");
                
                position.Quantity.Should()
                    .Be(initialLongQuantity - buyToOpenQuantity);
            }
        }

        [Fact]
        public void Detach_SellToCloseTransactionFromExistingPosition_IncreasesLongPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var initialLongQuantity = (decimal)100;
            position.Attach(TransactionType.BuyToOpen, initialLongQuantity);

            var sellToCloseQuantity = (decimal)50;

            // Act
            position.Detach(TransactionType.SellToClose, sellToCloseQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Long");
                
                position.Quantity.Should()
                    .Be(initialLongQuantity + sellToCloseQuantity);
            }
        }

        [Fact]
        public void Detach_SellToOpenTransactionFromExistingPosition_DecreasesShortPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var initialShortQuantity = (decimal)100;
            position.Attach(TransactionType.SellToOpen, initialShortQuantity);

            var sellToOpenQuantity = (decimal)50;

            // Act
            position.Detach(TransactionType.SellToOpen, sellToOpenQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Short");

                position.Quantity.Should()
                    .Be(initialShortQuantity - sellToOpenQuantity);
            }
        }

        [Fact]
        public void Detach_BuyToCloseTransactionFromExistingPosition_IncreasesShortPosition()
        {
            // Arrange
            Guid accessKey = Guid.NewGuid();
            string symbol = "ABC";

            var position = new Position(accessKey, symbol);

            var initialShortQuantity = (decimal)100;
            position.Attach(TransactionType.SellToOpen, initialShortQuantity);

            var buyToCloseQuantity = (decimal)50;

            // Act
            position.Detach(TransactionType.BuyToClose, buyToCloseQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be("Short");

                position.Quantity.Should()
                    .Be(initialShortQuantity + buyToCloseQuantity);
            }
        }
    }
}