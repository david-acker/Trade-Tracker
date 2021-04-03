using System;
using System.Collections.Generic;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Extensions;

namespace TradeTracker.Domain.UnitTests.Entities
{
    public class PositionTestData
    {
        private static Position CreateEmptyPosition()
        {
            return new Position(Guid.Empty, "");
        }

        private static Position CreatePositionFromTransaction(TransactionType type, decimal quantity)
        {
            var position = new Position(Guid.Empty, "");

            position.Attach(type, quantity);
                
            return position;
        }

        
        public static IEnumerable<object[]> AttachTransactionOfZeroToPositionTestData
        {
            get
            {
                yield return new object[]
                {
                    TransactionType.Buy,
                    CreateEmptyPosition()
                };
                yield return new object[]
                {
                    TransactionType.Sell, 
                    CreateEmptyPosition(),
                };
                yield return new object[]
                {
                    TransactionType.Buy, 
                    CreatePositionFromTransaction(
                        TransactionType.Buy, 
                        (decimal)100),
                };
                yield return new object[]
                {
                    TransactionType.Sell, 
                    CreatePositionFromTransaction(
                        TransactionType.Buy, 
                        (decimal)100),
                };
                yield return new object[]
                {
                    TransactionType.Sell, 
                    CreatePositionFromTransaction(
                        TransactionType.Sell, 
                        (decimal)100),
                };
                yield return new object[]
                {
                    TransactionType.Buy, 
                    CreatePositionFromTransaction(
                        TransactionType.Sell, 
                        (decimal)100),
                };
            }
        }


        public static IEnumerable<object[]> AttachToNewPositionTestData
        {
            get
            {
                yield return new object[]
                {
                    TransactionType.Buy, 
                    (decimal)100,
                    CreateEmptyPosition(),
                    (decimal)100,
                    ExposureType.Long
                };
                yield return new object[]
                {
                    TransactionType.Sell,
                    (decimal)100,
                    CreateEmptyPosition(),
                    (decimal)100,
                    ExposureType.Short
                };
            }
        }

        public static IEnumerable<object[]> AttachToExistingPositionTestData
        {  
            get
            {
                yield return new object[]
                {
                    TransactionType.Buy,
                    (decimal)50,
                    CreatePositionFromTransaction(
                        TransactionType.Buy, 
                        (decimal)100),
                    (decimal)150,
                    ExposureType.Long
                };
                yield return new object[]
                {
                    TransactionType.Sell,
                    (decimal)50,
                    CreatePositionFromTransaction(
                        TransactionType.Buy, 
                        (decimal)100),
                    (decimal)50,
                    ExposureType.Long
                };
                yield return new object[]
                {
                    TransactionType.Sell,
                    (decimal)150,
                    CreatePositionFromTransaction(
                        TransactionType.Buy, 
                        (decimal)100),
                    (decimal)50,
                    ExposureType.Short
                };
                yield return new object[]
                {
                    TransactionType.Sell,
                    (decimal)50,
                    CreatePositionFromTransaction(
                        TransactionType.Sell, 
                        (decimal)100),
                    (decimal)150,
                    ExposureType.Short
                };
                yield return new object[]
                {
                    TransactionType.Buy,
                    (decimal)50,
                    CreatePositionFromTransaction(
                        TransactionType.Sell, 
                        (decimal)100),
                    (decimal)50,
                    ExposureType.Short
                };
                yield return new object[]
                {
                    TransactionType.Buy,
                    (decimal)150,
                    CreatePositionFromTransaction(
                        TransactionType.Sell, 
                        (decimal)100),
                    (decimal)50,
                    ExposureType.Long
                };
            }
        }

        public static IEnumerable<object[]> DetachFromExistingPositionTestData
        {
            get
            {
                yield return new object[]
                {
                    TransactionType.Buy,
                    (decimal)50,
                    CreatePositionFromTransaction(
                        TransactionType.Buy, 
                        (decimal)100),
                    (decimal)50,
                    ExposureType.Long
                };
                yield return new object[]
                {
                    TransactionType.Sell,
                    (decimal)50,
                    CreatePositionFromTransaction(
                        TransactionType.Buy, 
                        (decimal)100),
                    (decimal)150,
                    ExposureType.Long
                };
                yield return new object[]
                {
                    TransactionType.Buy,
                    (decimal)100,
                    CreatePositionFromTransaction(
                        TransactionType.Buy, 
                        (decimal)50),
                    (decimal)50,
                    ExposureType.Short
                };
                yield return new object[]
                {
                    TransactionType.Sell,
                    (decimal)50,
                    CreatePositionFromTransaction(
                        TransactionType.Sell, 
                        (decimal)100),
                    (decimal)50,
                    ExposureType.Short
                };
                yield return new object[]
                {
                    TransactionType.Buy,
                    (decimal)50,
                    CreatePositionFromTransaction(
                        TransactionType.Sell, 
                        (decimal)100),
                    (decimal)150,
                    ExposureType.Short
                };
                yield return new object[]
                {
                    TransactionType.Sell,
                    (decimal)100,
                    CreatePositionFromTransaction(
                        TransactionType.Sell, 
                        (decimal)50),
                    (decimal)50,
                    ExposureType.Long
                };
            }
        }
    }
}
