using System;
using Moq;
using TradeTracker.Application.Common.Helpers;
using TradeTracker.Application.Common.Interfaces;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.UnitTests.Mocks
{
    public class EntityTagServiceMock
    {
        public static Mock<IEntityTagService> GetNullEntityTagService()
        {
            var mockNullEntityTagService = new Mock<IEntityTagService>();

            mockNullEntityTagService
                .Setup(service => service.GetEntityTagFromHeader())
                .Returns(() => 
                {
                    return null;
                });
            
            return mockNullEntityTagService;
        }

        public static Mock<IEntityTagService> GetEntityTagServiceWithMatchingTag()
        {
            var mockEntityTagServiceWithMatchingTag = new Mock<IEntityTagService>();

            var transactionForReturn = new TransactionForReturnDto()
            {
                TransactionId = Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49"),
                DateTime = new DateTime(2016, 1, 1),
                Symbol = "ABC",
                Type = TransactionType.Buy.ToString(),
                Quantity = (decimal)100,
                Notional = (decimal)1000,
                TradePrice = (decimal)10
            };

            string entityTag = EntityTagHelper.Generate(transactionForReturn);

            mockEntityTagServiceWithMatchingTag
                .Setup(service => service.GetEntityTagFromHeader())
                .Returns(() =>
                {
                    return entityTag;
                });

            return mockEntityTagServiceWithMatchingTag;
        }

        public static Mock<IEntityTagService> GetEntityTagServiceWithMismatchingTag()
        {
            var mockEntityTagServiceWithMismatchingTag = new Mock<IEntityTagService>();

            var transactionForReturn = new TransactionForReturnDto()
            {
                TransactionId = Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49"),
                DateTime = new DateTime(2016, 1, 1),
                Symbol = "CBA",
                Type = TransactionType.Buy.ToString(),
                Quantity = (decimal)100,
                Notional = (decimal)1000,
                TradePrice = (decimal)10
            };

            string entityTag = EntityTagHelper.Generate(transactionForReturn);

            mockEntityTagServiceWithMismatchingTag
                .Setup(service => service.GetEntityTagFromHeader())
                .Returns(() =>
                {
                    return entityTag;
                });

            return mockEntityTagServiceWithMismatchingTag;
        }
    }
}