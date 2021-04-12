using FluentAssertions;
using FluentAssertions.Execution;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Extensions;
using Xunit;

namespace TradeTracker.Domain.UnitTests.Extensions
{
    public class PositionExtensionsTests
    {
        [Theory]
        [MemberData(nameof(PositionExtensionsTestData.AttachTestData),
            MemberType = typeof(PositionExtensionsTestData))]
        public static void Attach_Transaction_UpdatesPosition(
            Position position,
            TransactionType attachedType,
            decimal attachedQuantity,
            ExposureType expectedExposure,
            decimal expectedQuantity)
        {
            // Act
            position.Attach(attachedType, attachedQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Quantity.Should()
                    .Be(expectedQuantity);

                position.Exposure.Should()
                    .Be(expectedExposure);
            }
        }

        [Theory]
        [MemberData(nameof(PositionExtensionsTestData.DetachTestData),
            MemberType = typeof(PositionExtensionsTestData))]
        public static void Detach_Transaction_UpdatesPosition(
            Position position,
            TransactionType detachedType,
            decimal detachedQuantity,
            ExposureType expectedExposure,
            decimal expectedQuantity)
        {
            // Act
            position.Detach(detachedType, detachedQuantity);

            // Assert
            using (new AssertionScope())
            {
                position.Quantity.Should()
                    .Be(expectedQuantity);

                position.Exposure.Should()
                    .Be(expectedExposure);
            }
        }
    }
}
