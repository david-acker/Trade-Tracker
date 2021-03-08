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
        public void Attach_ExistingPosition_QuantityShiftsByTheQuantityFromAttachedTransaction()
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
        public void Attach_ExistingPosition_SignOfQuantityFromAttachedTransactionIsIgnored()
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
        public void Attach_ExistingPosition_BuyToOpenIncreasesLongPosition()
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
        public void Attach_ExistingPosition_SellToCloseDecreasesLongPosition()
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
        public void Attach_ExistingPosition_SellToOpenIncreasesShortPosition()
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
        public void Attach_ExistingPosition_BuyToCloseDecreasesShortPosition()
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
        public void Detach_ExistingPosition_BuyToOpenDecreasesLongPosition()
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
        public void Detach_ExistingPosition_SellToCloseIncreasesLongPosition()
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
        public void Detach_ExistingPosition_SellToOpenDecreasesShortPosition()
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
        public void Detach_ExistingPosition_BuyToCloseIncreasesShortPosition()
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