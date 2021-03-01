using System;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Features.Portfolio.Queries.GetCurrentHoldings
{
    public static class PortfolioCalculator
    {
        public static decimal CalculateCurrentHolding(Transaction transaction)
        {
            switch (transaction.TransactionType)
            {
                case var t when (t == TransactionType.BuyToOpen || 
                                 t == TransactionType.BuyToClose):
                    return transaction.Quantity;

                case var t when (t == TransactionType.SellToOpen ||
                                 t == TransactionType.SellToClose):
                    return -transaction.Quantity;

                default:
                    return Decimal.Zero;
            }
        }
    }
}