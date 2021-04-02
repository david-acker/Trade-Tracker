using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
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
        private readonly Mock<IAuthenticatedTransactionRepository> _mockAuthenticatedTransactionRepository;

        public UpdateTransactionTests()
        {
            _mockAuthenticatedTransactionRepository = AuthenticatedTransactionRepositoryMock.GetRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TransactionsMappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidTransaction_UpdatesExistingTransaction()
        {
            // Arrange
            var handler = new UpdateTransactionCommandHandler(
                _mapper, _mockAuthenticatedTransactionRepository.Object);

            var transactionId = Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49");
            
            var command = new UpdateTransactionCommand()
            {
                TransactionId = transactionId, 
                DateTime = new DateTime(2015, 1, 1),
                Symbol = "XYZ",
                Type = TransactionType.Buy.ToString(),
                Quantity = (decimal)10,
                Notional = (decimal)10,
                TradePrice = (decimal)1
            };

            var expectedTransaction = _mapper.Map<Transaction>(command);

            // Act
            await handler.Handle(command, CancellationToken.None);
            var actualTransaction = await _mockAuthenticatedTransactionRepository.Object.GetByIdAsync(transactionId);

            // Assert
            using (new AssertionScope())
            {
                actualTransaction.TransactionId.Should()
                    .Be(command.TransactionId);

                actualTransaction.DateTime.Should()
                    .Be(command.DateTime);

                actualTransaction.Symbol.Should()
                    .Be(command.Symbol);

                actualTransaction.Type.Should()
                    .Be((TransactionType)Enum.Parse(typeof(TransactionType), command.Type));

                actualTransaction.Quantity.Should()
                    .Be(command.Quantity);

                actualTransaction.Notional.Should()
                    .Be(command.Notional);

                actualTransaction.TradePrice.Should()
                    .Be(command.TradePrice);
            }
        }

        [Fact]
        public async Task Handle_InvalidRequestMissingTransactionId_ThrowsValidationException()
        {
            // Arrange
            var handler = new UpdateTransactionCommandHandler(
                _mapper, _mockAuthenticatedTransactionRepository.Object);

            var command = new UpdateTransactionCommand();

            // Act
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<ValidationException>()
                .Where(e => e.ValidationErrors.Contains("A valid TransactionId is required."));
        }

        [Fact]
        public async Task Handle_NonExistentTransaction_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new UpdateTransactionCommandHandler(
                _mapper, _mockAuthenticatedTransactionRepository.Object);

            var transactionId = Guid.NewGuid();

            var command = new UpdateTransactionCommand()
            {
                TransactionId = transactionId,
                DateTime = new DateTime(2015, 1, 1),
                Symbol = "XYZ",
                Type = TransactionType.Buy.ToString(),
                Quantity = (decimal)10,
                Notional = (decimal)10,
                TradePrice = (decimal)1
            };

            // Act
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage($"Transaction ({transactionId}) is not found.");
        }

        [Fact]
        public async Task Handle_TransactionNotAssociatedWithAccessKey_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new UpdateTransactionCommandHandler(
                _mapper, _mockAuthenticatedTransactionRepository.Object);
 
            var transactionId = Guid.Parse("2eb3de2f-7869-41b5-9bfc-3867c844f6e7");

            var command = new UpdateTransactionCommand()
            {
                TransactionId = transactionId,
                DateTime = new DateTime(2015, 1, 1),
                Symbol = "XYZ",
                Type = TransactionType.Buy.ToString(),
                Quantity = (decimal)10,
                Notional = (decimal)10,
                TradePrice = (decimal)1
            };

            // Act
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage($"Transaction ({transactionId}) is not found.");            
        }
    }
}