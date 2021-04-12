using System;
using System.Collections.Generic;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Domain.Extensions
{
    public static class PositionExtensions
    {
        public static void Attach(this Position position, TransactionType type, decimal quantity)
        {
            position.Quantity += CreateSignedQuantityDelta(type, quantity);
            position.Reclassify();
        }

        public static void Attach(this Position position, Transaction transaction)
        {
            position.Attach(transaction.Type, transaction.Quantity);
        }

        public static void AttachBatch(this Position position, IEnumerable<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                if (transaction.Symbol == position.Symbol)
                {
                    position.Attach(transaction);
                }
            }
        }

        public static void Detach(this Position position, TransactionType type, decimal quantity)
        {
            position.Quantity -= CreateSignedQuantityDelta(type, quantity);
            position.Reclassify();
        }

        public static void Detach(this Position position, Transaction transaction)
        {
            position.Detach(transaction.Type, transaction.Quantity);
        }

        public static void DetachBatch(this Position position, IEnumerable<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                if (transaction.Symbol == position.Symbol)
                {
                    position.Detach(transaction);
                }
            }
        }

        public static bool IsClosed(this Position position)
        {
            return position.Quantity == decimal.Zero;
        }

        private static void Reclassify(this Position position)
        {
            position.Exposure = GetExposureType(position);
        }

        private static decimal CreateSignedQuantityDelta(TransactionType type, decimal quantity)
        {
            switch (type)
            {
                case TransactionType.Buy:
                    return Math.Abs(quantity);

                case TransactionType.Sell:
                    return -Math.Abs(quantity);

                default:
                    return decimal.Zero;
            }
        }

        private static ExposureType GetExposureType(Position position)
        {
            switch (position.Quantity)
            {
                case decimal q when q > decimal.Zero:
                    return ExposureType.Long;

                case decimal q when q < decimal.Zero:
                    return ExposureType.Short;
            
                default:
                    return ExposureType.None;
            }
        }
    }
}