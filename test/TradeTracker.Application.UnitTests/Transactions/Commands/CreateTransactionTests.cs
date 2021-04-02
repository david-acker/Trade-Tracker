using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Profiles;
using TradeTracker.Application.UnitTests.Mocks;
using TradeTracker.Domain.Enums;
using Xunit;

namespace TradeTracker.Application.UnitTests.Transactions.Commands
{
    public class CreateTransactionTests
    {
        private readonly Mock<ILoggedInUserService> _loggedInUserService;
        private readonly IMapper _mapper;
        private readonly Mock<IAuthenticatedTransactionRepository> _mockAuthenticatedTransactionRepository;

        public CreateTransactionTests()
        {
            _loggedInUserService = LoggedInUserServiceMock.GetUserService();
            _mockAuthenticatedTransactionRepository = AuthenticatedTransactionRepositoryMock.GetRepository();

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
            var handler = new CreateTransactionCommandHandler(
                _mapper, 
                _mockAuthenticatedTransactionRepository.Object);

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
            var transactionToReturn = await handler.Handle(command, CancellationToken.None);

            // Assert
            transactionToReturn.Should()
                .BeOfType<TransactionForReturnDto>();
        }

        [Fact]
        public async Task Handle_ValidTransaction_TransactionAddedToRepo()
        {
            // Arrange
            var handler = new CreateTransactionCommandHandler(
                _mapper, 
                _mockAuthenticatedTransactionRepository.Object);

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
            await handler.Handle(command, CancellationToken.None);

            var transactionFromRepo = 
                (await _mockAuthenticatedTransactionRepository.Object.GetUnpagedResponseAsync(null))
                .FirstOrDefault();

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