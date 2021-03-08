using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Features.Transactions.Queries.GetTransaction;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Profiles;
using TradeTracker.Application.UnitTests.Mocks;
using TradeTracker.Domain.Enums;
using Xunit;

namespace TradeTracker.Application.UnitTests.Transactions.Queries
{
    public class GetTransactionCollectionTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITransactionRepository> _mockTransactionRepository;

        public GetTransactionCollectionTests()
        {
            _mockTransactionRepository = TransactionRepositoryMock.GetRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsIEnumerableOfTransactionForReturnDto()
        {
            // Arrange
            var handler = new GetTransactionCollectionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var userAccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            var transactionIds = new List<Guid>()
            {
                Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49"),
                Guid.Parse("f29b3b88-4ba3-4f4c-b3d4-e5ba823b7bfd"),
                Guid.Parse("7aafd62c-7192-4a08-a258-0a95be5bd1a1"),
            };

            var query = new GetTransactionCollectionQuery()
            {
                AccessKey = userAccessKey,
                TransactionIds = transactionIds
            };

            // Act
            var transactionCollection = await handler.Handle(query, CancellationToken.None);

            // Assert
            transactionCollection.Should()
                .BeOfType<List<TransactionForReturnDto>>();
        }

        [Fact]
        public async Task Handle_ValidRequest_TransactionMatchesQueryParameters()
        {
            // Arrange
            var handler = new GetTransactionCollectionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var userAccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            var transactionIds = new List<Guid>()
            {
                Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49")
            };

            var query = new GetTransactionCollectionQuery()
            {
                AccessKey = userAccessKey,
                TransactionIds = transactionIds
            };

            // Act
            var transactionCollection = await handler.Handle(query, CancellationToken.None);

            // Assert
            transactionCollection.First().Should()
                .Match<TransactionForReturnDto>((t) => t.TransactionId == transactionIds.First());
        }

        [Fact]
        public async Task Handle_InvalidRequestMissingAccessKey_ThrowsValidationException()
        {
            // Arrange
            var handler = new GetTransactionCollectionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var transactionIds = new List<Guid>()
            {
                Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49"),
                Guid.Parse("f29b3b88-4ba3-4f4c-b3d4-e5ba823b7bfd"),
                Guid.Parse("7aafd62c-7192-4a08-a258-0a95be5bd1a1"),
            };

            var query = new GetTransactionCollectionQuery()
            {
                TransactionIds = transactionIds
            };

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<ValidationException>()
                .Where(e => e.ValdationErrors.Contains("An authentication issue has occurred. Please refresh and try again."));
        }

        [Fact]
        public async Task Handle_InvalidRequestWithNoTransactionIds_ThrowsValidationException()
        {
            // Arrange
            var handler = new GetTransactionCollectionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var userAccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            
            var query = new GetTransactionCollectionQuery()
            {
                AccessKey = userAccessKey,
            };

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<ValidationException>()
                .Where(e => e.ValdationErrors.Contains("The TransactionIds parameter is required."));
        }

        [Fact]
        public async Task Handle_InvalidRequestWithTooManyTransactionIds_ThrowsValidationException()
        {
            // Arrange
            var handler = new GetTransactionCollectionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var userAccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            
            var transactionIds = new List<Guid>();
            for (var i = 0; i < 101; i++)
            {
                transactionIds.Add(Guid.NewGuid());
            }

            var query = new GetTransactionCollectionQuery()
            {
                AccessKey = userAccessKey,
                TransactionIds = transactionIds
            };

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<ValidationException>()
                .Where(e => e.ValdationErrors.Contains("The number of TransactionIds in a single request may not exceed 100."));
        }

        [Fact]
        public async Task Handle_SingleNonExistentTransaction_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new GetTransactionCollectionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var userAccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            
            var transactionIds = new List<Guid>()
            {
                Guid.NewGuid()
            };

            var query = new GetTransactionCollectionQuery()
            {
                AccessKey = userAccessKey,
                TransactionIds = transactionIds
            };

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage($"Transaction ({transactionIds.Single()}) is not found.");
        }

        [Fact]
        public async Task Handle_MultipleNonExistentTransaction_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new GetTransactionCollectionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var userAccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");

            var firstNonExistentTransactionId = Guid.NewGuid();
            var secondNonExistentTranasctionId = Guid.NewGuid();

            var transactionIds = new List<Guid>()
            {
                firstNonExistentTransactionId,
                secondNonExistentTranasctionId 
            };

            var orderedTransactionIds = transactionIds
                .OrderBy(t => t)
                .Select(t => t.ToString())
                .ToList();

            var expectedIdsAsString = String.Join(", ", orderedTransactionIds);  

            var expectedMessage = $"The following Transactions were not found: ({expectedIdsAsString}).";
            
            var query = new GetTransactionCollectionQuery()
            {
                AccessKey = userAccessKey,
                TransactionIds = transactionIds
            };

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage(expectedMessage);
        }

        [Fact]
        public async Task Handle_TransactionNotAssociatedWithAccessKey_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new GetTransactionCollectionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var userAccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");

            var transactionIds = new List<Guid>()
            {
                Guid.Parse("2eb3de2f-7869-41b5-9bfc-3867c844f6e7")
            };

            var query = new GetTransactionCollectionQuery()
            {
                AccessKey = userAccessKey,
                TransactionIds = transactionIds
            };

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage($"Transaction ({transactionIds.Single()}) is not found.");            
        }
    }
}