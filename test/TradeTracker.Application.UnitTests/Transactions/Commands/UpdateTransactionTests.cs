using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
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
    }
}