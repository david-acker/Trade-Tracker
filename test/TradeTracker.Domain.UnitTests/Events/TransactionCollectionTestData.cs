using System;
using System.Collections.Generic;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Domain.UnitTests.Events
{
    public class TransactionCollectionTestData
    {
        public static IEnumerable<object[]> TestData
        {  
            get
            {
                yield return new object[]
                {
                    new List<Transaction>()
                    {
                        new Transaction()
                        {
                            DateTime = new DateTime(2020, 1, 1),
                            Symbol = "A",
                            Type = TransactionType.Buy,
                            Quantity = 5,
                            Notional = 10,
                            TradePrice = 2
                        },
                        new Transaction()
                        {
                            DateTime = new DateTime(2020, 1, 2),
                            Symbol = "B",
                            Type = TransactionType.Sell,
                            Quantity = 2,
                            Notional = 22,
                            TradePrice = 11
                        },
                        new Transaction()
                        {
                            DateTime = new DateTime(2020, 1, 3),
                            Symbol = "A",
                            Type = TransactionType.Sell,
                            Quantity = 4,
                            Notional = 12,
                            TradePrice = 3
                        }
                    }
                };
            }
        }
    }
}