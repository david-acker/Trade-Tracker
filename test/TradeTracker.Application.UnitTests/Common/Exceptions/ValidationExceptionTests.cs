using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.Results;
using TradeTracker.Application.Common.Exceptions;
using Xunit;

namespace TradeTracker.Application.UnitTests.Common.Exceptions
{
    public class ValidationExceptionTests
    {
        [Fact]
        public void Create_FromString_ContainsErrorMessage()
        {
            // Arrange
            var errorMessage = "Error Message";

            // Act
            var exception = new ValidationException(errorMessage);

            // Assert
            exception.ValidationErrors.Should()
                .Contain(errorMessage);

            exception.ValidationErrors.Should()
                .ContainSingle();
        }

        [Fact]
        public void Create_FromValidationResult_ContainsErrorMessages()
        {
            // Arrange
            var propertyNames = new List<string>() { "Property A", "Property B" };
            var errorMessages = new List<string>() { "Error Message A", "Error Message B" };

            var validationFailures = new List<ValidationFailure>()
            {
                new ValidationFailure(propertyNames[0], errorMessages[0]),
                new ValidationFailure(propertyNames[1], errorMessages[1])
            };

            var validationResult = new ValidationResult(validationFailures);

            // Act
            var exception = new ValidationException(validationResult);

            // Assert
            exception.ValidationErrors.Should()
                .BeEquivalentTo(errorMessages);
        }
    }
}