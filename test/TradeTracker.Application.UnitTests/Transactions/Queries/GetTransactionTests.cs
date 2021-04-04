using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using TradeTracker.Application.Common.Exceptions;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Profiles;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransaction;
using TradeTracker.Application.UnitTests.Mocks;
using Xunit;

namespace TradeTracker.Application.UnitTests.Transactions.Queries
{
    public class GetTransactionTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAuthenticatedTransactionRepository> _mockAuthenticatedTransactionRepository;

        public GetTransactionTests()
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
            var handler = new GetTransactionQueryHandler(
                _mockAuthenticatedTransactionRepository.Object,
                _mapper);

            var accessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            var transactionId = Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49");

            var query = new GetTransactionQuery() { TransactionId = transactionId };

            // Act
            var transaction = await handler.Handle(query, CancellationToken.None);
            
            // Assert
            transaction.Should()
                .Match<TransactionForReturnDto>((t) => t.TransactionId == transactionId);
        }

        [Fact]
        public async Task Handle_InvalidRequestMissingTransactionId_ThrowsValidationException()
        {
            // Arrange
            var handler = new GetTransactionQueryHandler(
                _mockAuthenticatedTransactionRepository.Object,
                _mapper);

            var accessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            
            var query = new GetTransactionQuery();

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<ValidationException>()
                .Where(e => e.ValidationErrors.Contains("A valid TransactionId is required."));
        }

        [Fact]
        public async Task Handle_NonExistentTransaction_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new GetTransactionQueryHandler(
                _mockAuthenticatedTransactionRepository.Object,
                _mapper);

            var transactionId = Guid.NewGuid();
            var accessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");

            var query = new GetTransactionQuery() { TransactionId = transactionId };

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage($"Transaction ({transactionId}) was not found.");
        }
    }
}