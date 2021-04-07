using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Models.Resources.Parameters.Transactions;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.UnitTests.Mocks
{
    public class AuthenticatedTransactionRepositoryMock
    {
        public static Mock<IAuthenticatedTransactionRepository> GetRepository()
        {
            var userAccessKeys = new Dictionary<int, Guid>()
            {
                { 0, Guid.Parse("e373eae5-9e71-43ad-8b31-09b141da6547") },
                { 1, Guid.Parse("36a3afa2-7edf-413a-925e-832fb2f3c529") }
            };

            var currentUserAccessKey = userAccessKeys[0];

            var transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    Id = Guid.Parse("3e2e267a-ab63-477f-92a0-7350ceac8d49"),
                    AccessKey = userAccessKeys[0],
                    DateTime = new DateTime(2016, 1, 1),
                    Symbol = "ABC",
                    Type = TransactionType.Buy,
                    Quantity = (decimal)100,
                    Notional = (decimal)1000,
                    TradePrice = (decimal)10
                },
                new Transaction()
                {
                    Id = Guid.Parse("f29b3b88-4ba3-4f4c-b3d4-e5ba823b7bfd"),
                    AccessKey = userAccessKeys[0],
                    DateTime = new DateTime(2017, 1, 1),
                    Symbol = "XYZ",
                    Type = TransactionType.Buy,
                    Quantity = (decimal)10,
                    Notional = (decimal)250,
                    TradePrice =(decimal)25
                },
                new Transaction()
                {
                    Id = Guid.Parse("7aafd62c-7192-4a08-a258-0a95be5bd1a1"),
                    AccessKey = userAccessKeys[0],
                    DateTime = new DateTime(2018, 1, 1),
                    Symbol = "ABC",
                    Type = TransactionType.Sell,
                    Quantity = (decimal)50,
                    Notional = (decimal)1000,
                    TradePrice =(decimal)20
                },
                new Transaction()
                {
                    Id = Guid.Parse("2eb3de2f-7869-41b5-9bfc-3867c844f6e7"),
                    AccessKey = userAccessKeys[1],
                    DateTime = new DateTime(2019, 1, 1),
                    Symbol = "ABC",
                    Type = TransactionType.Buy,
                    Quantity = (decimal)10,
                    Notional = (decimal)150,
                    TradePrice = (decimal)15
                },
                new Transaction()
                {
                    Id = Guid.Parse("49f371e5-298c-4aa2-9644-496b8678810e"),
                    AccessKey = userAccessKeys[1],
                    DateTime = new DateTime(2020, 1, 1),
                    Symbol = "XYZ",
                    Type = TransactionType.Buy,
                    Quantity = (decimal)5,
                    Notional = (decimal)100,
                    TradePrice = (decimal)20
                }
            };

            var mockTransactionRepository = new Mock<IAuthenticatedTransactionRepository>();
            
            mockTransactionRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid transactionId) => 
                {
                    return transactions
                        .Where(t => t.AccessKey == currentUserAccessKey)
                        .FirstOrDefault(t => t.Id == transactionId);
                });
            
            mockTransactionRepository
                .Setup(repo => repo.GetTransactionCollectionByIdsAsync(It.IsAny<IEnumerable<Guid>>()))
                .ReturnsAsync((IEnumerable<Guid> ids) =>
                {
                    return transactions
                        .Where(t => t.AccessKey == currentUserAccessKey)
                        .Where(t => ids.Contains(t.Id))
                        .ToList();
                });
            
            mockTransactionRepository
                .Setup(repo => repo.GetUnpagedResponseAsync(It.IsAny<UnpagedTransactionsResourceParameters>()))
                .ReturnsAsync((UnpagedTransactionsResourceParameters parameters) =>
                {
                    return transactions
                        .Where(t => t.AccessKey == currentUserAccessKey)
                        .ToList();
                });
            
            mockTransactionRepository
                .Setup(repo => repo.AddAsync(It.IsAny<Transaction>()))
                .ReturnsAsync((Transaction transaction) =>
                {
                    transaction.AccessKey = currentUserAccessKey;

                    transactions.Add(transaction);
                    return transaction;
                });

            mockTransactionRepository
                .Setup(repo => repo.AddRangeAsync(It.IsAny<IEnumerable<Transaction>>()))
                .ReturnsAsync((IEnumerable<Transaction> newTransactions) =>
                {
                    transactions = transactions
                        .Select(transaction => 
                        {
                            transaction.AccessKey = currentUserAccessKey;
                            return transaction;
                        })
                        .ToList();

                    transactions.AddRange(newTransactions);
                    return newTransactions;
                });

            mockTransactionRepository
                .Setup(repo => repo.UpdateAsync(It.IsAny<Transaction>()))
                .Verifiable();
            
            mockTransactionRepository
                .Setup(repo => repo.DeleteAsync(It.IsAny<Transaction>()))
                .Verifiable();
            
            return mockTransactionRepository;
        }
    }
}
