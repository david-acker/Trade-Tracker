using System;
using TradeTracker.Application.Common.Enums;

namespace TradeTracker.Application.Common.Helpers
{
    public static class OrderByParser
    {
        public static string extractField(
            string input,
            char separator = ' ')
        {
            return input
                .Trim()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)[0]
                .Trim();
        }

        public static string extractSortTypeString(
            string input,
            char separator = ' ')
        {
            return input
                .Trim()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)[1]
                .Trim();
        }

        public static SortType extractSortType(
            string input,
            char separator = ' ')
        {
            var sortTypeString = extractSortTypeString(input, separator);

            SortType sortType = SortType.NotSpecified;
            Enum.TryParse(sortTypeString, true, out sortType);

            return sortType;
        }
    }
}