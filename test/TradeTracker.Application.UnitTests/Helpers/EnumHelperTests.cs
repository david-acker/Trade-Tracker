using System.Collections.Generic;
using FluentAssertions;
using TradeTracker.Application.Common.Helpers;
using TradeTracker.Application.UnitTests.Helpers.TestData;
using Xunit;

namespace TradeTracker.Application.UnitTests.Helpers
{
    public class EnumHelperTests
    {
        [Theory]
        [MemberData(nameof(EnumHelperTestData.IsNotDefaultTestData),
            MemberType = typeof(EnumHelperTestData))]
        public void Handle_InputForIsNotDefault_ReturnsCorrectResult(
            string input,
            bool expectedResult)
        {
            // Act
            var result = EnumHelper.IsNotDefault<TestEnum>(input);

            // Assert
            result.Should()
                .Be(expectedResult);
        }

        [Theory]
        [MemberData(nameof(EnumHelperTestData.ToListTestData),
            MemberType = typeof(EnumHelperTestData))]
        public void Handle_InputForToList_ReturnsCorrectList(
            int? startIndex,
            List<string> expectedResult)
        {
            // Act
            List<string> result;

            if (startIndex != null)
                result = EnumHelper.ToList<TestEnum>((int)startIndex);
            else
                result = EnumHelper.ToList<TestEnum>();

            // Assert
            result.Should()
                .Equal(expectedResult);
        }

        #nullable enable

        [Theory]
        [MemberData(nameof(EnumHelperTestData.DisplayTestData),
            MemberType = typeof(EnumHelperTestData))]
        public void Handle_Display_ReturnsCorrectString(
            int? startIndex,
            string? separator,
            string expectedResult)
        {
            // Act
            string result;

            if (startIndex != null)
            {
                if (separator != null)
                    result = EnumHelper.Display<TestEnum>(
                        startIndex: (int)startIndex,
                        separator: separator);
                else
                    result = EnumHelper.Display<TestEnum>(
                        startIndex: (int)startIndex);
            }
            else
            {
                if (separator != null)
                    result = EnumHelper.Display<TestEnum>(
                        separator: separator);
                else
                    result = EnumHelper.Display<TestEnum>();
            }

            // Assert
            result.Should()
                .Be(expectedResult);
        }

        #nullable disable
    }
}