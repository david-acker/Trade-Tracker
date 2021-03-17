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
        public void Create_NewPosition_StartsEmpty()
        {
            // Act
            var position = new Position(Guid.Empty, "");

            // Assert
            using (new AssertionScope())
            {
                position.Quantity.Should()
                    .Be(Decimal.Zero);

                position.Exposure.Should()
                    .Be("None");

                position.IsClosed.Should()
                    .BeTrue();
            }
        }

        [Theory]
        [InlineData(TransactionType.Buy, 0)]
        [InlineData(TransactionType.Sell, 0)]
        public void Attach_TransactionOfZeroToEmptyPosition_CausesNoChanges(
            TransactionType transactionType,
            int transactionQuantity)
        {
            // Arrange
            var position = new Position(Guid.Empty, "");

            // Act
            position.Attach(transactionType, (decimal)transactionQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Quantity.Should()
                    .Be(Decimal.Zero);
                
                position.Exposure.Should()
                    .Be("None");
                
                position.IsClosed.Should()
                    .BeTrue();
            }
        }

        [Theory]
        [MemberData(nameof(PositionTestData.AttachTransactionOfZeroToPositionTestData),
            MemberType = typeof(PositionTestData))]
        public void Attach_TransactionOfZeroToExistingPosition_CausesNoChanges(
            TransactionType attachedTransactionType,
            Position position)
        {
            // Arrange
            decimal originalPositionQuantity = position.Quantity;
            string originalPositionExposure = position.Exposure;
            bool originalPositionIsClosed = position.IsClosed;

            // Act
            position.Attach(attachedTransactionType, Decimal.Zero);

            // Assert
            using (new AssertionScope())
            {
                position.Quantity.Should()
                    .Be(originalPositionQuantity);
                
                position.Exposure.Should()
                    .Be(originalPositionExposure);
                
                position.IsClosed.Should()
                    .Be(originalPositionIsClosed);
            }
        }

        [Theory]
        [InlineData(TransactionType.Buy, 100)]
        [InlineData(TransactionType.Sell, 100)]
        public void Check_ExistingPositionWithNonZeroQuantity_IsClosedIsFalse(
            TransactionType transactionType,
            int transactionQuantity)
        {
            // Arrange
            var position = new Position(Guid.Empty, "");

            // Act
            position.Attach(transactionType, (decimal)transactionQuantity);

            // Assert
            position.IsClosed.Should()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(PositionTestData.AttachToNewPositionTestData),
            MemberType = typeof(PositionTestData))]
        public void Attach_TransactionToEmptyPosition_MatchesTransaction(
            TransactionType attachedTransactionType,
            decimal attachedTransactionQuantity,
            Position position,
            decimal expectedPositionQuantity,
            string expectedPositionExposure)
        {
            // Act
            position.Attach(
                attachedTransactionType, 
                attachedTransactionQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be(expectedPositionExposure);
                
                position.Quantity.Should()
                    .Be(expectedPositionQuantity);
            }
        }

        [Theory]
        [MemberData(nameof(PositionTestData.AttachToExistingPositionTestData),
            MemberType = typeof(PositionTestData))]
        public void Attach_TransactionToExistingPosition_ShiftsByTransaction(
            TransactionType attachedTransactionType,
            decimal attachedTransactionQuantity,
            Position position,
            decimal expectedPositionQuantity,
            string expectedPositionExposure)
        {
            // Act
            position.Attach(
                attachedTransactionType, 
                attachedTransactionQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be(expectedPositionExposure);

                position.Quantity.Should()
                    .Be(expectedPositionQuantity);
            }
        }

        [Theory]
        [MemberData(nameof(PositionTestData.DetachFromExistingPositionTestData),
            MemberType = typeof(PositionTestData))]
        public void Detach_TransactionToExistingPosition_ShiftsByTransaction(
            TransactionType attachedTransactionType,
            decimal attachedTransactionQuantity,
            Position position,
            decimal expectedPositionQuantity,
            string expectedPositionExposure)
        {
            // Act
            position.Detach(
                attachedTransactionType, 
                attachedTransactionQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Exposure.Should()
                    .Be(expectedPositionExposure);

                position.Quantity.Should()
                    .Be(expectedPositionQuantity);
            }
        }
    }
}