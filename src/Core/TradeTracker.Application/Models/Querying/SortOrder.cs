using System;
using System.Collections.Generic;
using System.Linq;
using TradeTracker.Application.Enums;

namespace TradeTracker.Api.Models.Querying
{
    public class SortOrder
    {
        public string Field { get; } = "DateTime";
        public SortOrderType Type { get; } = SortOrderType.Descending;

        public SortOrder() { }
        public SortOrder(string sortOrderString)
        {
            var cleanedSortOrderString = sortOrderString.Trim();

            Field = extractField(cleanedSortOrderString);
            Type = extractType(cleanedSortOrderString);
        }

        private string extractField(string sortOrderString)
        {
            return sortOrderString
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]
                .Trim();
        }

        private SortOrderType extractType(string sortOrderString)
        {
            var typeString = sortOrderString
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]
                .Trim();
        
            var type = SortOrderType.Descending;
            Enum.TryParse(typeString, true, out type);

            return type;
        }      
    }
}