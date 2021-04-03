using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Profiles;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.UnitTests.Mocks;
using TradeTracker.Domain.Enums;
using Xunit;

namespace TradeTracker.Application.UnitTests.Transactions.Commands
{
    public class CreateTransactionTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAuthenticatedTransactionRepository> _mockAuthenticatedTransactionRepository;

        public CreateTransactionTests()
        {
            _mockAuthenticatedTransactionRepository = AuthenticatedTransactionRepositoryMock.GetRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TransactionsMappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidTransaction_TransactionAddedToRepo()
        {
            // Arrange
            var handler = new CreateTransactionCommandHandler(
                _mockAuthenticatedTransactionRepository.Object,
                _mapper);

            var command = new CreateTransactionCommand()
            {
                DateTime = new DateTime(2015, 1, 1),
                Symbol = "XYZ",
                Type = TransactionType.Buy.ToString(),
                Quantity = (decimal)10,
                Notional = (decimal)10,
                TradePrice = (decimal)1
            };

            // Act
            var createdTransaction = await handler.Handle(command, CancellationToken.None);

            var transactionFromRepo = await _mockAuthenticatedTransactionRepository.Object
                .GetByIdAsync(createdTransaction.TransactionId);

            // Assert
            using (new AssertionScope())
            {
                transactionFromRepo.DateTime.Should()
                    .Be(command.DateTime);

                transactionFromRepo.Symbol.Should()
                    .Be(command.Symbol);

                transactionFromRepo.Type.Should()
                    .Be((TransactionType)Enum.Parse(typeof(TransactionType), command.Type));

                transactionFromRepo.Quantity.Should()
                    .Be(command.Quantity);

                transactionFromRepo.Notional.Should()
                    .Be(command.Notional);

                transactionFromRepo.TradePrice.Should()
                    .Be(command.TradePrice);
            }
        }
    }
}