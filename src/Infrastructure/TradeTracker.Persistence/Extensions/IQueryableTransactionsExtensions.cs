using System;
using System.Linq;
using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Interfaces.Resources.Requests;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Persistence.Extensions
{
    public static class IQueryableTransactionsExtensions
    {
        public static IQueryable<Transaction> ForTransactionType(
            this IQueryable<Transaction> query, 
            TransactionType type)
        {
            if (type != TransactionType.NotSpecified)
            {
                query = query.Where(t => t.Type == type);
            }

            return query;
        }

        public static IQueryable<Transaction> ForSymbolSelection(
            this IQueryable<Transaction> query,
            ISymbolSelection selection)
        {
            if (selection.Type != SelectionType.NotSpecified)
            {
                if (selection.Symbols.Any())
                {
                    if (selection.Type == SelectionType.Include)
                    {
                        query = query.Where(p => selection.Symbols.Any(x => x == p.Symbol));
                    }
                    else
                    {
                        query = query.Where(p => !selection.Symbols.Any(x => x == p.Symbol));
                    }
                }
            }

            return query;
        }

        public static IQueryable<Transaction> ForOrderBy(
            this IQueryable<Transaction> query,
            ITransactionOrderBy orderBy)
        {
            if (String.IsNullOrWhiteSpace(orderBy.Field))
            {
                orderBy.Field = "datetime";
            }

            if (orderBy.Type == SortType.Ascending)
            {
                switch (orderBy.Field)
                {
                    case "symbol":
                        query = query.OrderBy(p => p.Symbol);
                        break;
                    
                    case "quantity":
                        query = query.OrderBy(p => p.Quantity);
                        break;

                    case "notional":
                        query = query.OrderBy(p => p.Notional);
                        break;

                    case "datetime":
                    default:
                        query = query.OrderBy(p => p.DateTime);
                        break;
                }
            }
            else
            {
                switch (orderBy.Field)
                {
                    case "symbol":
                        query = query.OrderByDescending(p => p.Symbol);
                        break;
                    
                    case "quantity":
                        query = query.OrderByDescending(p => p.Quantity);
                        break;

                    case "notional":
                        query = query.OrderByDescending(p => p.Notional);
                        break;

                    case "datetime":
                    default:
                        query = query.OrderByDescending(p => p.DateTime);
                        break;
                }
            }
            
            return query;
        }

        public static IQueryable<Transaction> ForRangeStart(
            this IQueryable<Transaction> query,
            DateTime rangeStart)
        {
            if (rangeStart.Date != DateTime.MinValue.Date)
            {
                query = query.Where(t => t.DateTime > rangeStart);
            }

            return query;
        }

        public static IQueryable<Transaction> ForRangeEnd(
            this IQueryable<Transaction> query,
            DateTime rangeEnd)
        {
            if (rangeEnd != DateTime.MinValue.Date 
                && rangeEnd != DateTime.MaxValue.Date)
            {
                query = query.Where(t => t.DateTime < rangeEnd);
            }

            return query;
        }
    }
}