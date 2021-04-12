using System.Collections.Generic;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Domain.UnitTests.Extensions
{
    public class PositionExtensionsTestData
    {
        public static IEnumerable<object[]> AttachTestData
        {
            get
            {
                // Starting Exposure: None
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.None,
                        Quantity = 0m,
                    },
                    TransactionType.NotSpecified,
                    0m,
                    ExposureType.None,
                    0m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.None,
                        Quantity = 0m,
                    },
                    TransactionType.Buy,
                    1m,
                    ExposureType.Long,
                    1m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.None,
                        Quantity = 0m
                    },
                    TransactionType.Sell,
                    1m,
                    ExposureType.Short,
                    -1m
                };

                // Starting Exposure: Long
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Long,
                        Quantity = 1m,
                    },
                    TransactionType.NotSpecified,
                    0m,
                    ExposureType.Long,
                    1m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Long,
                        Quantity = 1m
                    },
                    TransactionType.Buy,
                    1m,
                    ExposureType.Long,
                    2m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Long,
                        Quantity = 2m
                    },
                    TransactionType.Sell,
                    1m,
                    ExposureType.Long,
                    1m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Long,
                        Quantity = 1m
                    },
                    TransactionType.Sell,
                    1m,
                    ExposureType.None,
                    0m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Long,
                        Quantity = 1m
                    },
                    TransactionType.Sell,
                    2m,
                    ExposureType.Short,
                    -1m
                };

                // Starting Exposure: Short
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Short,
                        Quantity = -1m,
                    },
                    TransactionType.NotSpecified,
                    0m,
                    ExposureType.Short,
                    -1m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Short,
                        Quantity = -1m
                    },
                    TransactionType.Sell,
                    1m,
                    ExposureType.Short,
                    -2m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Short,
                        Quantity = -2m
                    },
                    TransactionType.Buy,
                    1m,
                    ExposureType.Short,
                    -1m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Short,
                        Quantity = -1m
                    },
                    TransactionType.Buy,
                    1m,
                    ExposureType.None,
                    0m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Short,
                        Quantity = -1m
                    },
                    TransactionType.Buy,
                    2m,
                    ExposureType.Long,
                    1m
                };
            }
        }

        public static IEnumerable<object[]> DetachTestData
        {
            get
            {
                // Starting Exposure: None
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.None,
                        Quantity = 0m,
                    },
                    TransactionType.NotSpecified,
                    0m,
                    ExposureType.None,
                    0m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.None,
                        Quantity = 0m,
                    },
                    TransactionType.Buy,
                    1m,
                    ExposureType.Short,
                    -1m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.None,
                        Quantity = 0m,
                    },
                    TransactionType.Sell,
                    1m,
                    ExposureType.Long,
                    1m
                };

                // Starting Exposure: Long
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Long,
                        Quantity = 1m,
                    },
                    TransactionType.NotSpecified,
                    0m,
                    ExposureType.Long,
                    1m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Long,
                        Quantity = 1m
                    },
                    TransactionType.Sell,
                    1m,
                    ExposureType.Long,
                    2m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Long,
                        Quantity = 2m
                    },
                    TransactionType.Buy,
                    1m,
                    ExposureType.Long,
                    1m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Long,
                        Quantity = 1m
                    },
                    TransactionType.Buy,
                    1m,
                    ExposureType.None,
                    0m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Long,
                        Quantity = 1m
                    },
                    TransactionType.Buy,
                    2m,
                    ExposureType.Short,
                    -1m
                };

                // Starting Exposure: Short
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Short,
                        Quantity = -1m,
                    },
                    TransactionType.NotSpecified,
                    0m,
                    ExposureType.Short,
                    -1m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Short,
                        Quantity = -1m
                    },
                    TransactionType.Buy,
                    1m,
                    ExposureType.Short,
                    -2m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Short,
                        Quantity = -2m
                    },
                    TransactionType.Sell,
                    1m,
                    ExposureType.Short,
                    -1m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Short,
                        Quantity = -1m
                    },
                    TransactionType.Sell,
                    1m,
                    ExposureType.None,
                    0m
                };
                yield return new object[]
                {
                    new Position()
                    {
                        Symbol = "A",
                        Exposure = ExposureType.Short,
                        Quantity = -1m
                    },
                    TransactionType.Sell,
                    2m,
                    ExposureType.Long,
                    1m
                };
            }
        }

        // Only test:
        //  Attach multiple transactions:
        //
        //      Long: + Buy, Buy
        //      Long: + Sell, Sell
        //      Long: + Buy, Sell
        //      Long: + Any Two Transactions (one w/ Symbol, one w/o)
        //
        //      Short: + Buy, Buy
        //      Short: + Sell, Sell
        //      Short: + Buy, Sell
        //      Short: + Any Two Transactions (one w/ Symbol, one w/o)
        //
        public static IEnumerable<object[]> AttachBatchTestData
        {
            get
            {
                yield return new object[]
                {

                };
            }
        }

        // Only test:
        //  Detach multiple transactions:
        //
        //      Long: + Buy, Buy
        //      Long: + Sell, Sell
        //      Long: + Buy, Sell
        //      Long: + Any Two Transactions (one w/ Symbol, one w/o)
        //
        //      Short: + Buy, Buy
        //      Short: + Sell, Sell
        //      Short: + Buy, Sell
        //      Short: + Any Two Transactions (one w/ Symbol, one w/o)
        //
        public static IEnumerable<object[]> DetachBatchTestData
        {
            get
            {
                yield return new object[]
                {

                };
            }
        }

        public static IEnumerable<object[]> IsClosedTestData
        {
            get
            {
                yield return new object[]
                {

                };
            }
        }
    }
}
