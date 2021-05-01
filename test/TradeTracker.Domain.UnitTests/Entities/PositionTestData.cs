using System.Collections.Generic;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Domain.UnitTests.Entities
{
    public class PositionTestData
    {
        public static IEnumerable<object[]> AttachTypeAndQuantityData
        {
            get
            {
                yield return new object[]
                {
                    new Position(),
                    TransactionType.Buy,
                    1m,
                    1m
                };
                yield return new object[]
                {
                    new Position(),
                    TransactionType.Sell,
                    1m,
                    -1m
                };
                yield return new object[]
                {
                    new Position() { Quantity = 1m },
                    TransactionType.Buy,
                    1m,
                    2m
                };
                yield return new object[]
                {
                    new Position() { Quantity = -1m },
                    TransactionType.Sell,
                    1m,
                    -2m
                };
                yield return new object[]
                {
                    new Position() { Quantity = 1m },
                    TransactionType.Sell,
                    1m,
                    0m
                };
                yield return new object[]
                {
                    new Position() { Quantity = 1m },
                    TransactionType.Sell,
                    2m,
                    -1m
                };
                yield return new object[]
                {
                    new Position() { Quantity = -1m },
                    TransactionType.Buy,
                    1m,
                    0m
                };
                yield return new object[]
                {
                    new Position() { Quantity = -1m },
                    TransactionType.Buy,
                    2m,
                    1m
                };
            }
        }

        public static IEnumerable<object[]> AttachTypeAndSignedQuantityData
        {
            get
            {
                yield return new object[]
                {
                    TransactionType.Buy,
                    -1m,
                    1m
                };
                yield return new object[]
                {
                    TransactionType.Sell,
                    -1m,
                    -1m
                };
            }
        }

        public static IEnumerable<object[]> AttachTransactionData
        {
            get
            {
                yield return new object[]
                {
                    new Transaction()
                    {
                        Type = TransactionType.Buy,
                        Quantity = 1m
                    },
                    1m
                };
                yield return new object[]
                {
                    new Transaction()
                    {
                        Type = TransactionType.Sell,
                        Quantity = 1m
                    },
                    -1m
                };
            }
        }

        public static IEnumerable<object[]> AttachTransactionWithSymbolData
        {
            get
            {
               yield return new object[]
               {
                    new Position()
                    {
                        Symbol = "A",
                    },
                    new Transaction()
                    {
                        Symbol = "A",
                        Type = TransactionType.Buy,
                        Quantity = 1m
                    },
                    1m
               };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A"
                    },
                    new Transaction()
                    {
                        Symbol = "B",
                        Type = TransactionType.Buy,
                        Quantity = 1m
                    },
                    0m
                };
            }
        }

        public static IEnumerable<object[]> AttachTransactionBatchData
        {
            get
            {
                yield return new object[]
                {
                    new List<Transaction>()
                    {
                        new Transaction()
                        {
                            Type = TransactionType.Buy,
                            Quantity = 3m
                        },
                        new Transaction()
                        {
                            Type = TransactionType.Sell,
                            Quantity = 2m
                        }
                    },
                    1m
                };
            }
        }

        public static IEnumerable<object[]> DetachTypeAndQuantityData
        {
            get
            {
                yield return new object[]
                {
                    new Position(),
                    TransactionType.Buy,
                    1m,
                    -1m
                };
                yield return new object[]
                {
                    new Position(),
                    TransactionType.Sell,
                    1m,
                    1m
                };
                yield return new object[]
                {
                    new Position() 
                    { 
                        Quantity = 1m 
                    },
                    TransactionType.Buy,
                    1m,
                    0m
                };
                yield return new object[]
                {
                    new Position() 
                    { 
                        Quantity = -1m 
                    },
                    TransactionType.Sell,
                    1m,
                    0m
                };
                yield return new object[]
                {
                    new Position() 
                    { 
                        Quantity = 1m 
                    },
                    TransactionType.Sell,
                    1m,
                    2m
                };
                yield return new object[]
                {
                    new Position() 
                    { 
                        Quantity = -1m 
                    },
                    TransactionType.Sell,
                    2m,
                    1m
                };
                yield return new object[]
                {
                    new Position() 
                    { 
                        Quantity = -1m 
                    },
                    TransactionType.Buy,
                    1m,
                    -2m
                };
                yield return new object[]
                {
                    new Position() 
                    { 
                        Quantity = 1m
                    },
                    TransactionType.Buy,
                    2m,
                    -1m
                };
            }
        }
        public static IEnumerable<object[]> DetachTypeAndSignedQuantityData
        {
            get
            {
                yield return new object[]
                {
                    TransactionType.Buy,
                    -1m,
                    -1m
                };
                yield return new object[]
                {
                    TransactionType.Sell,
                    -1m,
                    1m
                };
            }
        }

        public static IEnumerable<object[]> DetachTransactionData
        {
            get
            {
                yield return new object[]
                {
                    new Transaction()
                    {
                        Type = TransactionType.Buy,
                        Quantity = 1m
                    },
                    -1m
                };
                yield return new object[]
                {
                    new Transaction()
                    {
                        Type = TransactionType.Sell,
                        Quantity = 1m
                    },
                    1m
                };
            }
        } 

        public static IEnumerable<object[]> DetachTransactionWithSymbolData
        {
            get
            {
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Quantity = 1m
                    },
                    new Transaction()
                    {
                        Symbol = "A",
                        Type = TransactionType.Buy,
                        Quantity = 1m
                    },
                    0m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Quantity = 1m
                    },
                    new Transaction()
                    {
                        Symbol = "B",
                        Type = TransactionType.Buy,
                        Quantity = 1m
                    },
                    1m
                };
            }
        }
        public static IEnumerable<object[]> DetachTransactionBatchData
        {
            get
            {
                yield return new object[]
                {
                    new List<Transaction>()
                    {
                        new Transaction()
                        {
                            Type = TransactionType.Buy,
                            Quantity = 3m
                        },
                        new Transaction()
                        {
                            Type = TransactionType.Sell,
                            Quantity = 2m
                        }
                    },
                    -1m
                };
            }
        }

        public static IEnumerable<object[]> IsClosedData
        {
            get
            {
                yield return new object[]
                {
                    new Position(),
                    true
                };
                yield return new object[]
                {
                    new Position()
                    { 
                        Quantity = 1m 
                    },
                    false
                };
                yield return new object[]
                {
                    new Position() 
                    { 
                        Quantity = -1m
                    },
                    false
                };
            }
        }

        public static IEnumerable<object[]> ExposureData
        {
            get
            {
                yield return new object[]
                {
                    new Position(),
                    ExposureType.None
                };
                yield return new object[]
                {
                    new Position() 
                    {
                        Quantity = 1m 
                    },
                    ExposureType.Long
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Quantity = -1m 
                    },
                    ExposureType.Short
                };
            }
        }
    }
}
