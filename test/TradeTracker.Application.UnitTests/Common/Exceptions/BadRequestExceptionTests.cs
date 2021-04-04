using FluentAssertions;
using TradeTracker.Application.Common.Exceptions;
using Xunit;

namespace TradeTracker.Application.UnitTests.Common.Exceptions
{
    public class BadRequestExceptionTests
    {
        [Fact]
        public void Create_WithMessage_ContainsMessage()
        {
            // Arrange
            string message = "Message";

            // Act
            var exception = new BadRequestException(message);

            // Assert
            exception.Message.Should()
                .Be(message);
        }
    }
}