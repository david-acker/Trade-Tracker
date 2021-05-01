using System;
using System.Collections.Generic;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Interfaces;

namespace TradeTracker.Domain.Entities
{
    public class Position : AuditableEntity, IAuthorizableEntity
    {
        public string Symbol { get; set; }

        public decimal Quantity { get; set; } = decimal.Zero;

        public Position() { }

        public Position(Guid accessKey, string symbol)
        {
            AccessKey = accessKey;
            Symbol = symbol;
        }

        public bool IsClosed => Quantity == decimal.Zero;

        public ExposureType Exposure => GetExposure();

        private ExposureType GetExposure()
        {
            switch (Quantity)
            {
                case decimal q when q > decimal.Zero:
                    return ExposureType.Long;

                case decimal q when q < decimal.Zero:
                    return ExposureType.Short;
            
                default:
                    return ExposureType.None;
            }
        }

        public void Attach(TransactionType type, decimal quantity)
        {
            Quantity += CreateSignedQuantityDelta(type, quantity);
        }

        public void Attach(Transaction transaction)
        {
            if (transaction.Symbol == Symbol)
            {
                Attach(transaction.Type, transaction.Quantity);
            }
        }

        public void AttachBatch(IEnumerable<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                Attach(transaction);
            }
        }

        public void Detach(TransactionType type, decimal quantity)
        {
            Quantity -= CreateSignedQuantityDelta(type, quantity);
        }

        public void Detach(Transaction transaction)
        {
            if (transaction.Symbol == Symbol)
            {
                Detach(transaction.Type, transaction.Quantity);
            }
        }

        public void DetachBatch(IEnumerable<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                Detach(transaction);
            }
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
    }
}