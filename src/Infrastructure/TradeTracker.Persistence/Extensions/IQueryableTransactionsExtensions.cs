using System;
using System.Linq;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Interfaces;

namespace TradeTracker.Persistence.Extensions
{
    public static class IQueryableTransactionsExtensions
    {
        public static IQueryable<T> ForTransactionType<T>(this IQueryable<T> query, string transactionType)
            where T : Transaction
        {
            switch (transactionType)
            {
                case "buy":
                    query = query.Where(t => t.Type == TransactionType.Buy);
                    break;

                case "sell":
                    query = query.Where(t => t.Type == TransactionType.Sell);
                    break;

                default:
                    break;
            }

            return query;
        }
    }
}
