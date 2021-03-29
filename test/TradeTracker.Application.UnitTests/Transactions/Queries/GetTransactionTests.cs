using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Features.Transactions.Queries.GetTransaction;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Profiles;
using TradeTracker.Application.UnitTests.Mocks;
using TradeTracker.Domain.Enums;
using Xunit;

namespace TradeTracker.Application.UnitTests.Transactions.Queries
{
    public class GetTransactionTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITransactionRepository> _mockTransactionRepository;

        public GetTransactionTests()
        {
            _mockTransactionRepository = TransactionRepositoryMock.GetRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TransactionsMappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsTransactionForReturnDto()
        {
            // Arrange
            var handler = new GetTransactionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var accessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            var transactionId = Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49");

            var query = new GetTransactionQuery()
            {
                TransactionId = transactionId
            };

            query.Authenticate(accessKey);

            // Act
            var transaction = await handler.Handle(query, CancellationToken.None);

            // Assert
            transaction.Should()
                .BeOfType<TransactionForReturnDto>();
        }

        [Fact]
        public async Task Handle_ValidRequest_TransactionMatchesQueryParameters()
        {
            // Arrange
            var handler = new GetTransactionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var accessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            var transactionId = Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49");

            var query = new GetTransactionQuery()
            {
                TransactionId = transactionId
            };

            query.Authenticate(accessKey);

            // Act
            var transaction = await handler.Handle(query, CancellationToken.None);
            
            // Assert
            transaction.Should()
                .Match<TransactionForReturnDto>((t) => t.TransactionId == transactionId);
        }

        [Fact]
        public async Task Handle_InvalidRequestMissingAccessKey_ThrowsValidationException()
        {
            // Arrange
            var handler = new GetTransactionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var transactionId = Guid.NewGuid();
            
            var query = new GetTransactionQuery()
            {
                TransactionId = transactionId
            };

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<ValidationException>()
                .Where(e => e.ValdationErrors.Contains("An authentication issue has occurred. Please refresh and try again."));
        }

        [Fact]
        public async Task Handle_InvalidRequestMissingTransactionId_ThrowsValidationException()
        {
            // Arrange
            var handler = new GetTransactionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var accessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            
            var query = new GetTransactionQuery();

            query.Authenticate(accessKey);

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<ValidationException>()
                .Where(e => e.ValdationErrors.Contains("A valid TransactionId is required."));
        }

        [Fact]
        public async Task Handle_NonExistentTransaction_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new GetTransactionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var transactionId = Guid.NewGuid();
            var accessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");

            var query = new GetTransactionQuery()
            {
                TransactionId = transactionId
            };

            query.Authenticate(accessKey);

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage($"Transaction ({transactionId}) is not found.");
        }

        [Fact]
        public async Task Handle_TransactionNotAssociatedWithAccessKey_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new GetTransactionQueryHandler(_mapper, _mockTransactionRepository.Object);

            var transactionId = Guid.Parse("2eb3de2f-7869-41b5-9bfc-3867c844f6e7");
            var accessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");

            var query = new GetTransactionQuery()
            {
                TransactionId = transactionId
            };

            query.Authenticate(accessKey);

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage($"Transaction ({transactionId}) is not found.");            
        }
    }
}