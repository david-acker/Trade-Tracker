using FluentAssertions;
using System.Collections.Generic;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using Xunit;

namespace TradeTracker.Domain.UnitTests.Entities
{
    public class PositionTests
    {
        [Fact]
        public void Position_starts_with_quantity_of_zero()
        {
            // Act
            var sut = new Position();

            // Assert
            sut.Quantity.Should()
                .Be(0m);
        }

        [Fact]
        public void Attaching_an_unspecified_type_does_not_shift_the_position_quantity()
        {
            // Arrange
            var sut = new Position();

            var attachedTransaction = new Transaction()
            {
                Type = TransactionType.NotSpecified,
                Quantity = 1m
            };

            // Act
            sut.Attach(attachedTransaction);

            // Act
            sut.Quantity.Should()
                .Be(0m);
        }

        [Theory]
        [InlineData(TransactionType.Buy)]
        [InlineData(TransactionType.Sell)]
        public void Attaching_a_quantity_of_zero_does_not_shift_the_position_quantity(
            TransactionType attachedType)
        {
            // Arrange
            var sut = new Position();

            var attachedTransaction = new Transaction()
            {
                Type = attachedType,
                Quantity = 0m
            };

            // Act
            sut.Attach(attachedTransaction);

            // Assert
            sut.Quantity.Should()
                .Be(0m);
        }

        [Theory]
        [MemberData(nameof(PositionTestData.AttachTypeAndQuantityData),
            MemberType = typeof(PositionTestData))]
        public void Attaching_a_type_and_quantity_shifts_the_position_quantity(
            Position sut,
            TransactionType attachedType,
            decimal attachedQuantity,
            decimal expectedQuantity)
        {
            // Act
            sut.Attach(attachedType, attachedQuantity);

            // Assert
            sut.Quantity.Should()
                .Be(expectedQuantity);
        }

        [Theory]
        [MemberData(nameof(PositionTestData.AttachTypeAndSignedQuantityData),
            MemberType = typeof(PositionTestData))]
        public void Attaching_a_type_and_quantity_does_not_depend_on_the_sign_of_quantity(
            TransactionType attachedType,
            decimal attachedQuantity,
            decimal expectedQuantity)
        {
            // Arrange
            var sut = new Position();

            // Act
            sut.Attach(attachedType, attachedQuantity);

            // Assert
            sut.Quantity.Should()
                .Be(expectedQuantity);
        }

        [Theory]
        [MemberData(nameof(PositionTestData.AttachTransactionData),
            MemberType = typeof(PositionTestData))]
        public void Attaching_a_transaction_shifts_the_position_quantity(
            Transaction attachedTransaction,
            decimal expectedQuantity)
        {
            // Arrange
            var sut = new Position();

            // Act
            sut.Attach(attachedTransaction);

            // Assert
            sut.Quantity.Should()
                .Be(expectedQuantity);
        }

        [Theory]
        [MemberData(nameof(PositionTestData.AttachTransactionWithSymbolData),
            MemberType = typeof(PositionTestData))]
        public void Attaching_a_transaction_checks_that_symbols_match(
            Position sut,
            Transaction attachedTransaction,
            decimal expectedQuantity)
        {
            // Act
            sut.Attach(attachedTransaction);

            // Assert
            sut.Quantity.Should()
                .Be(expectedQuantity);
        }

        [Theory]
        [MemberData(nameof(PositionTestData.AttachTransactionBatchData),
            MemberType = typeof(PositionTestData))]
        public void Attaching_a_transaction_batch_shifts_the_position_quantity(
            IEnumerable<Transaction> transactionBatch,
            decimal expectedQuantity)
        {
            // Arrange
            var sut = new Position();

            // Act
            sut.AttachBatch(transactionBatch);

            // Assert
            sut.Quantity.Should()
                .Be(expectedQuantity);
        }

        [Fact]
        public void Detaching_an_unspecified_type_does_not_shift_the_position_quantity()
        {
            // Arrange
            var sut = new Position();

            var attachedTransaction = new Transaction()
            {
                Type = TransactionType.NotSpecified,
                Quantity = 1m
            };

            // Act
            sut.Detach(attachedTransaction);

            // Act
            sut.Quantity.Should()
                .Be(0m);
        }

        [Theory]
        [InlineData(TransactionType.Buy)]
        [InlineData(TransactionType.Sell)]
        public void Detaching_a_quantity_of_zero_does_not_shift_the_position_quantity(
            TransactionType detachedType)
        {
            // Arrange
            var sut = new Position();

            var attachedTransaction = new Transaction()
            {
                Type = detachedType,
                Quantity = 0m
            };

            // Act
            sut.Detach(attachedTransaction);

            // Assert
            sut.Quantity.Should()
                .Be(0m);
        }

        [Theory]
        [MemberData(nameof(PositionTestData.DetachTypeAndQuantityData),
            MemberType = typeof(PositionTestData))]
        public void Detaching_a_type_and_quantity_shifts_the_position_quantity(
            Position sut,
            TransactionType detachedType,
            decimal detachedQuantity,
            decimal expectedQuantity)
        {
            // Act
            sut.Detach(detachedType, detachedQuantity);

            // Assert
            sut.Quantity.Should()
                .Be(expectedQuantity);
        }

        [Theory]
        [MemberData(nameof(PositionTestData.DetachTypeAndSignedQuantityData),
            MemberType = typeof(PositionTestData))]
        public void Detaching_a_type_and_quantity_does_not_depend_on_the_sign_of_quantity(
            TransactionType detachedType,
            decimal detachedQuantity,
            decimal expectedQuantity)
        {
            // Arrange
            var sut = new Position();

            // Act
            sut.Detach(detachedType, detachedQuantity);

            // Assert
            sut.Quantity.Should()
                .Be(expectedQuantity);
        }

        [Theory]
        [MemberData(nameof(PositionTestData.DetachTransactionData),
            MemberType = typeof(PositionTestData))]
        public void Detaching_a_transaction_shifts_the_position_quantity(
            Transaction detachedTransaction,
            decimal expectedQuantity)
        {
            // Arrange
            var sut = new Position();

            // Act
            sut.Detach(detachedTransaction);

            // Assert
            sut.Quantity.Should()
                .Be(expectedQuantity);
        }

        [Theory]
        [MemberData(nameof(PositionTestData.DetachTransactionWithSymbolData),
            MemberType = typeof(PositionTestData))]
        public void Detaching_a_transaction_checks_that_symbols_match(
            Position sut,
            Transaction detachedTransaction,
            decimal expectedQuantity)
        {
            // Act
            sut.Detach(detachedTransaction);

            // Assert
            sut.Quantity.Should()
                .Be(expectedQuantity);
        }

        [Theory]
        [MemberData(nameof(PositionTestData.DetachTransactionBatchData),
            MemberType = typeof(PositionTestData))]
        public void Detaching_a_transaction_batch_shifts_the_position_quantity(
            IEnumerable<Transaction> transactionBatch,
            decimal expectedQuantity)
        {
            // Arrange
            var sut = new Position();

            // Act
            sut.DetachBatch(transactionBatch);

            // Assert
            sut.Quantity.Should()
                .Be(expectedQuantity);
        }

        [Theory]
        [MemberData(nameof(PositionTestData.IsClosedData),
            MemberType = typeof(PositionTestData))]
        public void IsClosed_property_returns_the_correct_boolean_state(
            Position sut,
            bool expectedState)
        {
            // Act
            bool actualState = sut.IsClosed;

            // Assert
            actualState.Should()
                .Be(expectedState);
        }

        [Theory]
        [MemberData(nameof(PositionTestData.ExposureData),
            MemberType = typeof(PositionTestData))]
        public void Exposure_property_returns_the_correct_exposure_type(
            Position sut,
            ExposureType expectedExposure)
        {
            // Act
            ExposureType actualExposure = sut.Exposure;

            // Assert
            actualExposure.Should()
                .Be(expectedExposure);
        }
    }
}