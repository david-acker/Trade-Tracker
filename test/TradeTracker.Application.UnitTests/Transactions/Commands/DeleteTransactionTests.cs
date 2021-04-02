using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Profiles;
using TradeTracker.Application.UnitTests.Mocks;
using Xunit;

namespace TradeTracker.Application.UnitTests.Transactions.Commands
{
    public class DeleteTransactionTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAuthenticatedTransactionRepository> _mockAuthenticatedTransactionRepository;

        public DeleteTransactionTests()
        {
            _mockAuthenticatedTransactionRepository = AuthenticatedTransactionRepositoryMock.GetRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TransactionsMappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ExistingTransaction_ReturnsMediatRUnit()
        {
            // Arrange
            var handler = new DeleteTransactionCommandHandler(_mapper, _mockAuthenticatedTransactionRepository.Object);

            var command = new DeleteTransactionCommand()
            {
                TransactionId = Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49")
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should()
                .BeOfType<Unit>();
        }

        [Fact]
        public async Task Handle_NonExistentTransaction_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new DeleteTransactionCommandHandler(_mapper, _mockAuthenticatedTransactionRepository.Object);

            var transactionId = Guid.NewGuid();
            
            var command = new DeleteTransactionCommand() { TransactionId = transactionId };

            // Act
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage($"Transaction ({transactionId}) is not found.");
        }
    }
}