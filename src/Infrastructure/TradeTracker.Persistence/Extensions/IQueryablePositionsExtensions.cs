using System;
using System.Linq;
using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Interfaces.Resources.Requests;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Persistence.Extensions
{
    public static class IQueryablePositionsExtensions
    {
        public static IQueryable<Position> ForExposureType(
            this IQueryable<Position> query, 
            ExposureType type)
        {
            if (type != ExposureType.NotSpecified)
            {
                query = query.Where(p => p.Exposure == type);
            }

            return query;
        }

        public static IQueryable<Position> ForSymbolSelection(
            this IQueryable<Position> query,
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

        public static IQueryable<Position> ForOrderBy(
            this IQueryable<Position> query,
            IPositionOrderBy orderBy)
        {
            if (String.IsNullOrWhiteSpace(orderBy.Field))
            {
                orderBy.Field = "quantity";
            }

            if (orderBy.Type == SortType.Ascending)
            {
                switch (orderBy.Field)
                {
                    case "symbol":
                        query = query.OrderBy(p => p.Symbol);
                        break;

                    case "quantity":
                    default:
                        query = query.OrderBy(p => p.Quantity);
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
                    default:
                        query = query.OrderByDescending(p => p.Quantity);
                        break;
                }
            }

            return query;
        }
    }
}