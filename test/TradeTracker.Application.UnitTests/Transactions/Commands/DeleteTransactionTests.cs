using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using TradeTracker.Application.Common.Exceptions;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Profiles;
using TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction;
using TradeTracker.Application.UnitTests.Mocks;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
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
        public async Task Handle_NonExistentTransaction_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new DeleteTransactionCommandHandler(
                _mockAuthenticatedTransactionRepository.Object, 
                _mapper);

            var transactionId = Guid.NewGuid();
            
            var command = new DeleteTransactionCommand() { TransactionId = transactionId };

            // Act
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);
            
            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage($"Transaction ({transactionId}) was not found.");
        }

        [Fact]
        public async Task Handle_ExistingTransaction_DeletedFromRepo()
        {
            // Arrange
            var handler = new DeleteTransactionCommandHandler(
                _mockAuthenticatedTransactionRepository.Object, 
                _mapper);

            var transactionId = Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49");
            
            var command = new DeleteTransactionCommand() { TransactionId = transactionId };

            var deletedTransaction = new Transaction()
            {
                TransactionId = Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49"),
                AccessKey = Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547"),
                DateTime = new DateTime(2016, 1, 1),
                Symbol = "ABC",
                Type = TransactionType.Buy,
                Quantity = (decimal)100,
                Notional = (decimal)1000,
                TradePrice = (decimal)10
            };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            _mockAuthenticatedTransactionRepository
                .Verify(mock => mock.DeleteAsync(It.IsAny<Transaction>()), Times.Once());
        }        
    }
}