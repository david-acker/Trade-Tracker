using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using TradeTracker.Application.Common.Exceptions;
using Xunit;

namespace TradeTracker.Application.UnitTests.Common.Exceptions
{
    public class NotFoundExceptionTests
    {
        [Fact]
        public void Create_FromSingleKey_ContainsMessageForSingleKey()
        {
            // Arrange
            string name = "Name";
            object key = "Key";

            // Act
            var exception = new NotFoundException(name, key);

            // Assert
            exception.Message.Should()
                .Be($"{name} ({key}) was not found.");
        }

        [Fact]
        public void Create_FromEnumerableWithMultipleKeys_ContainsMessageForMultipleKeys()
        {
            // Arrange
            string name = "Name";
            IEnumerable<object> keys = new List<string>() { "Key A", "Key B" };

            var keysAsString = String.Join(", ", keys);

            // Act
            var exception = new NotFoundException(name, keys);

            // Assert
            exception.Message.Should()
                .Be($"The following {name}s were not found: ({keysAsString}).");
        }

        [Fact]
        public void Create_FromEnumerableWithSingleKey_ContainsMessageForSingleKey()
        {
            // Arrange
            string name = "Name";
            IEnumerable<object> keys = new List<string>() { "Key A" };

            // Act
            var exception = new NotFoundException(name, keys);

            // Assert
            exception.Message.Should()
                .Be($"{name} ({keys.Single()}) was not found.");
        }
    }
}