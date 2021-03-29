using System;
using FluentAssertions;
using TradeTracker.Application.Requests;
using Xunit;

namespace TradeTracker.Application.UnitTests.Requests
{
    public class AuthenticatedRequestTests
    {
        [Fact]
        public void Create_NewRequest_AccessKeyStartEmpty()
        {
            // Act
            var request = new AuthenticatedRequest();

            // Assert
            request.AccessKey.Should()
                .Be(Guid.Empty);
        }

        [Fact]
        public void Authenticate_NewRequest_AccessKeySet()
        {
            // Arrange
            var request = new AuthenticatedRequest();

            var accessKey = Guid.NewGuid();

            // Act
            request.Authenticate(accessKey);

            // Assert
            request.AccessKey.Should()
                .Be(accessKey);
        }
    }
}