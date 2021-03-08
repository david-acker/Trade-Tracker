using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Profiles;
using TradeTracker.Application.UnitTests.Mocks;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using Xunit;

namespace TradeTracker.Application.UnitTests.Transactions.Commands
{
    public class UpdateTransactionTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITransactionRepository> _mockTransactionRepository;

        public UpdateTransactionTests()
        {
            _mockTransactionRepository = TransactionRepositoryMock.GetRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidTransaction_UpdatesExistingTransaction()
        {
            // Arrange
            var handler = new UpdateTransactionCommandHandler(_mapper, _mockTransactionRepository.Object);

            var transactionId = Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49");
            var userAccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");

            var command = new UpdateTransactionCommand()
            {
                TransactionId = transactionId, 
                AccessKey = userAccessKey,
                DateTime = new DateTime(2015, 1, 1),
                Symbol = "XYZ",
                Type = TransactionType.BuyToOpen.ToString(),
                Quantity = (decimal)10,
                Notional = (decimal)10,
                TradePrice = (decimal)1
            };

            var expectedTransaction = _mapper.Map<Transaction>(command);

            // Act
            await handler.Handle(command, CancellationToken.None);
            var actualTransaction = await _mockTransactionRepository.Object.GetByIdAsync(userAccessKey, transactionId);

            // Assert
            using (new AssertionScope())
            {
                actualTransaction.TransactionId.Should().Be(expectedTransaction.TransactionId);
                actualTransaction.AccessKey.Should().Be(expectedTransaction.AccessKey);
                actualTransaction.DateTime.Should().Be(expectedTransaction.DateTime);
                actualTransaction.Symbol.Should().Be(expectedTransaction.Symbol);
                actualTransaction.Type.Should().Be(expectedTransaction.Type);
                actualTransaction.Quantity.Should().Be(expectedTransaction.Quantity);
                actualTransaction.Notional.Should().Be(expectedTransaction.Notional);
                actualTransaction.TradePrice.Should().Be(expectedTransaction.TradePrice);
            }
        }

        [Fact]
        public async Task Handle_InvalidRequestMissingAccessKey_ThrowsValidationException()
        {
            // Arrange
            var handler = new UpdateTransactionCommandHandler(_mapper, _mockTransactionRepository.Object);

            var transactionId = Guid.NewGuid();
            
            var query = new UpdateTransactionCommand()
            {
                TransactionId = transactionId,
                DateTime = new DateTime(2015, 1, 1),
                Symbol = "XYZ",
                Type = TransactionType.BuyToOpen.ToString(),
                Quantity = (decimal)10,
                Notional = (decimal)10,
                TradePrice = (decimal)1
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
            var handler = new UpdateTransactionCommandHandler(_mapper, _mockTransactionRepository.Object);

            var userAccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            
            var query = new UpdateTransactionCommand()
            {
                AccessKey = userAccessKey
            };

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
            var handler = new UpdateTransactionCommandHandler(_mapper, _mockTransactionRepository.Object);

            var userAccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            var transactionId = Guid.NewGuid();

            var query = new UpdateTransactionCommand()
            {
                AccessKey = userAccessKey,
                TransactionId = transactionId,
                DateTime = new DateTime(2015, 1, 1),
                Symbol = "XYZ",
                Type = TransactionType.BuyToOpen.ToString(),
                Quantity = (decimal)10,
                Notional = (decimal)10,
                TradePrice = (decimal)1
            };

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
            var handler = new UpdateTransactionCommandHandler(_mapper, _mockTransactionRepository.Object);

            var userAccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547");
            var transactionId = Guid.Parse("2eb3de2f-7869-41b5-9bfc-3867c844f6e7");

            var query = new UpdateTransactionCommand()
            {
                AccessKey = userAccessKey,
                TransactionId = transactionId,
                DateTime = new DateTime(2015, 1, 1),
                Symbol = "XYZ",
                Type = TransactionType.BuyToOpen.ToString(),
                Quantity = (decimal)10,
                Notional = (decimal)10,
                TradePrice = (decimal)1
            };

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage($"Transaction ({transactionId}) is not found.");            
        }
    }
}