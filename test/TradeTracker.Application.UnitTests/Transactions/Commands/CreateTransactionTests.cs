using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Profiles;
using TradeTracker.Application.UnitTests.Mocks;
using TradeTracker.Domain.Enums;
using Xunit;

namespace TradeTracker.Application.UnitTests.Transactions.Commands
{
    public class CreateTransactionTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITransactionRepository> _mockTransactionRepository;

        public CreateTransactionTests()
        {
            _mockTransactionRepository = TransactionRepositoryMock.GetRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TransactionsMappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidTransaction_ReturnsTransactionForReturnDto()
        {
            // Arrange
            var handler = new CreateTransactionCommandHandler(_mapper, _mockTransactionRepository.Object);

            var command = new CreateTransactionCommand()
            {
                DateTime = new DateTime(2015, 1, 1),
                Symbol = "XYZ",
                Type = TransactionType.Buy.ToString(),
                Quantity = (decimal)10,
                Notional = (decimal)10,
                TradePrice = (decimal)1
            };
            
            var accessKey = Guid.NewGuid();
            command.Authenticate(accessKey);

            // Act
            var transactionToReturn = await handler.Handle(command, CancellationToken.None);

            // Assert
            transactionToReturn.Should()
                .BeOfType<TransactionForReturnDto>();
        }

        [Fact]
        public async Task Handle_ValidTransaction_TransactionAddedToRepo()
        {
            // Arrange
            var handler = new CreateTransactionCommandHandler(_mapper, _mockTransactionRepository.Object);

            var command = new CreateTransactionCommand()
            {
                DateTime = new DateTime(2015, 1, 1),
                Symbol = "XYZ",
                Type = TransactionType.Buy.ToString(),
                Quantity = (decimal)10,
                Notional = (decimal)10,
                TradePrice = (decimal)1
            };

            var accessKey = Guid.NewGuid();
            command.Authenticate(accessKey);

            // Act
            await handler.Handle(command, CancellationToken.None);
            var allTransactionsForUser = await _mockTransactionRepository.Object.ListAllAsync(accessKey);

            // Assert
            allTransactionsForUser.Should()
                .ContainSingle();
        }
    }
}