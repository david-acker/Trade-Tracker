using System;
using System.ComponentModel.DataAnnotations;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Domain.Entities
{
    public class Position : AuditableEntity
    {
        public Position(Guid accessKey, string symbol)
        {
            AccessKey = accessKey;
            Symbol = symbol;
        }

        [Key]
        public Guid PositionId { get; private set; } = Guid.NewGuid();

        public Guid AccessKey { get; init; }

        public string Symbol { get; init; }

        public string Exposure { get; private set; } = ExposureType.None.ToString();

        private decimal _quantity = Decimal.Zero;
        public decimal Quantity => Math.Abs(this._quantity);

        public bool IsClosed { get; private set; } = true;


        public void Attach(TransactionType type, decimal quantity)
        {
            _quantity += CreateSignedQuantityDelta(type, quantity);

            Reclassify();
        }

        public void Detach(TransactionType type, decimal quantity)
        {
            _quantity -= CreateSignedQuantityDelta(type, quantity);

            Reclassify();
        }

        private decimal CreateSignedQuantityDelta(TransactionType type, decimal quantity)
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

        private void Reclassify()
        {
            Exposure = GetExposureType().ToString();
            IsClosed = CheckIfClosed();
        }

        private ExposureType GetExposureType()
        {
            switch (this._quantity)
            {
                case decimal q when q > Decimal.Zero:
                    return ExposureType.Long;
                
                case decimal q when q < Decimal.Zero:
                    return ExposureType.Short;
                
                default:
                    return ExposureType.None;
            }
        }

        private bool CheckIfClosed()
        {
            var isClosed = false;

            if (_quantity == Decimal.Zero)
            {
                isClosed = true;
            }

            return isClosed;
        }
    }
}