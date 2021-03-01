using System;
using System.Collections.Generic;
using System.Linq;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Persistence.Seed.Transactions.Helpers;

namespace TradeTracker.Persistence.Seed.Transactions
{
    public static class TransactionSeeder
    {
        public static IEnumerable<Transaction> GenerateEquityTransactions(string accessKey, int transactionCount)
        {
            DateTime start = DateTime.SpecifyKind(new DateTime(2018, 1, 1), DateTimeKind.Utc);

            var random = new Random();

            var transactions = new Transaction[transactionCount];

            for (var i = 0; i < transactionCount; i++)
            {
                DateTime dateTime = DateTimeGenerator.GenerateOpenMarketDateTime(random, start);
                string equitySymbol = SymbolGenerator.GenerateEquitySymbol(random, 3);

                TransactionType transactionType = (random.NextDouble() >= 0.5) 
                    ? TransactionType.BuyToOpen 
                    : TransactionType.SellToClose;
                
                decimal tradePrice = DecimalGenerator.GenerateInRange(random, (decimal)1.00, (decimal)100.00);
                decimal quantity = DecimalGenerator.GenerateInRange(random, (decimal)0.05, (decimal)5.00);
                decimal notional = decimal.Round(tradePrice * quantity, 2);

                transactions[i] = new Transaction()
                {
                    TransactionId = Guid.NewGuid(),
                    AccessKey = accessKey,
                    DateTime = dateTime,
                    Symbol = equitySymbol,
                    TransactionType = transactionType,
                    Quantity = quantity,
                    Notional = notional,
                    TradePrice = tradePrice,
                };
            }

            return transactions;
        }
    }
}