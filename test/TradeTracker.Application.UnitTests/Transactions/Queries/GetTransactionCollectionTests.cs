using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using TradeTracker.Application.Common.Exceptions;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Profiles;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection;
using TradeTracker.Application.UnitTests.Mocks;
using Xunit;

namespace TradeTracker.Application.UnitTests.Transactions.Queries
{
    public class GetTransactionCollectionTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAuthenticatedTransactionRepository> _mockAuthenticatedTransactionRepository;

        public GetTransactionCollectionTests()
        {
            _mockAuthenticatedTransactionRepository = AuthenticatedTransactionRepositoryMock.GetRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TransactionsMappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidRequest_TransactionMatchesQueryParameters()
        {
            // Arrange
            var handler = new GetTransactionCollectionQueryHandler(
                _mockAuthenticatedTransactionRepository.Object,
                _mapper);

            var transactionIds = new List<Guid>()
            {
                Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49")
            };

            var query = new GetTransactionCollectionQuery() { TransactionIds = transactionIds };

            // Act
            var transactionCollection = await handler.Handle(query, CancellationToken.None);

            // Assert
            transactionCollection.First().Should()
                .Match<TransactionForReturnDto>((t) => t.TransactionId == transactionIds.First());
        }

        [Fact]
        public async Task Handle_InvalidRequestWithNoTransactionIds_ThrowsValidationException()
        {
            // Arrange
            var handler = new GetTransactionCollectionQueryHandler(
                _mockAuthenticatedTransactionRepository.Object,
                _mapper);

            var query = new GetTransactionCollectionQuery();

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<ValidationException>()
                .Where(e => e.ValidationErrors.Contains("The TransactionIds parameter is required."));
        }

        [Fact]
        public async Task Handle_InvalidRequestWithTooManyTransactionIds_ThrowsValidationException()
        {
            // Arrange
            var handler = new GetTransactionCollectionQueryHandler(
                _mockAuthenticatedTransactionRepository.Object,
                _mapper);

            var transactionIds = new List<Guid>();
            for (var i = 0; i < 101; i++)
            {
                transactionIds.Add(Guid.NewGuid());
            }

            var query = new GetTransactionCollectionQuery() { TransactionIds = transactionIds };

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<ValidationException>()
                .Where(e => e.ValidationErrors.Contains("The number of TransactionIds in a single request may not exceed 100."));
        }

        [Fact]
        public async Task Handle_SingleNonExistentTransaction_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new GetTransactionCollectionQueryHandler(
                _mockAuthenticatedTransactionRepository.Object,
                _mapper);

            var transactionIds = new List<Guid>() { Guid.NewGuid() };

            var query = new GetTransactionCollectionQuery() { TransactionIds = transactionIds };

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
            var handler = new GetTransactionCollectionQueryHandler(
                _mockAuthenticatedTransactionRepository.Object,
                _mapper);

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
            
            var query = new GetTransactionCollectionQuery() { TransactionIds = transactionIds };

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage(expectedMessage);
        }
    }
}