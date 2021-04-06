using FluentAssertions;
using TradeTracker.Application.Common.Exceptions;
using Xunit;

namespace TradeTracker.Application.UnitTests.Common.Exceptions
{
    public class ResourceStateConflictExceptionTests
    {
        [Fact]
        public void Create_WithMessageFromString_ContainsMessage()
        {
            // Arrange
            string message = "Message";

            // Act
            var exception = new ResourceStateConflictException(message);

            // Assert
            exception.Message.Should()
                .Be(message);
        }

        [Fact]
        public void Create_WithMessageFromNameAndKey_ContainsMessage()
        {
            // Arrange
            string name = "Name";
            string key = "Key";

            string expectedMessage = "The representation of the Name (Key) was changed.";


            // Act
            var exception = new ResourceStateConflictException(name, key);

            // Assert
            exception.Message.Should()
                .Be(expectedMessage);
        }
    }
}