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
            AccessKey = AccessKey;
            Symbol = symbol;
        }

        [Key]
        public Guid PositionId { get; private set; } = Guid.NewGuid();

        public Guid AccessKey { get; private set; }

        public string Symbol { get; private set; }


        public string Exposure { get; private set; }

        private decimal _quantity = Decimal.Zero;
        public decimal Quantity => Math.Abs(this._quantity);

        public bool IsClosed { get; private set; }


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
                case TransactionType.BuyToOpen:
                case TransactionType.BuyToClose:
                    return quantity;
                
                case TransactionType.SellToOpen:
                case TransactionType.SellToClose:
                    return -quantity;
                
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