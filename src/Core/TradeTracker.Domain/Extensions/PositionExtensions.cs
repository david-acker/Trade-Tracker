using System;
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

        public static void Detach(this Position position, TransactionType type, decimal quantity)
        {
            position.Quantity -= CreateSignedQuantityDelta(type, quantity);

            position.Reclassify();
        }

        public static bool IsClosed(this Position position)
        {
            return position.Quantity == Decimal.Zero;
        }

        private static void Reclassify(this Position position)
        {
            position.Exposure = position.GetExposureType();
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
                    return Decimal.Zero;
            }
        }

        private static ExposureType GetExposureType(this Position position)
        {
            switch (position.Quantity)
            {
                case decimal q when q > Decimal.Zero:
                    return ExposureType.Long;

                case decimal q when q < Decimal.Zero:
                    return ExposureType.Short;
            
                default:
                    return ExposureType.None;
            }
        }
    }
}