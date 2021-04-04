using FluentAssertions;
using TradeTracker.Application.Common.Helpers;
using TradeTracker.Application.UnitTests.Helpers.TestData;
using Xunit;

namespace TradeTracker.Application.UnitTests.Helpers
{
    public class DateTimeRangeHelperTests
    {
        [Theory]
        [MemberData(nameof(DateTimeRangeHelperTestData.IsValidDateTimeTestData),
            MemberType = typeof(DateTimeRangeHelperTestData))]
        public void Handle_IsValidDateTime_ReturnsCorrectResult(
            string input,
            bool expectedResult)
        {
            // Act
            var result = DateTimeRangeHelper.IsValidDateTime(input);

            // Assert
            result.Should()
                .Be(expectedResult);
        }

        [Theory]
        [MemberData(nameof(DateTimeRangeHelperTestData.IsStartBeforeEndTestData),
            MemberType = typeof(DateTimeRangeHelperTestData))]
        public void Handle_IsStartBeforeEnd_ReturnsCorrectResult(
            string startInput, 
            string endInput,
            bool expectedResult)
        {
            // Act
            var result = DateTimeRangeHelper.IsStartBeforeEnd(startInput, endInput);

            // Assert
            result.Should()
                .Be(expectedResult);
        }

        [Theory]
        [MemberData(nameof(DateTimeRangeHelperTestData.IsNotDefaultTestData),
            MemberType = typeof(DateTimeRangeHelperTestData))]
        public void Handle_IsNotDefault_ReturnsCorrectResult(
            string input,
            bool expectedResult)
        {
            // Act
            var result = DateTimeRangeHelper.IsNotDefault(input);

            // Assert
            result.Should()
                .Be(expectedResult);
        }        
    }
}