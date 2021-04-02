using System;
using Moq;
using TradeTracker.Application.Interfaces;

namespace TradeTracker.Application.UnitTests.Mocks
{
    public class LoggedInUserServiceMock
    {
        public static Mock<ILoggedInUserService> GetUserService()
        {
            Guid userAccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");

            var mockLoggedInUserService = new Mock<ILoggedInUserService>();

            mockLoggedInUserService
                .Setup(service => service.AccessKey)
                .Returns((Guid accessKey, Guid transactionId) => 
                {
                    return userAccessKey;
                });
            
            return mockLoggedInUserService;
        }
    }
}