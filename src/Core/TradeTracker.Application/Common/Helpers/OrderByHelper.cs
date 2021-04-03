using System;
using TradeTracker.Application.Common.Enums;

namespace TradeTracker.Application.Common.Helpers
{
    public static class OrderByHelper
    {
        public static bool isSortTypeSpecified(string input)
        {
            var isSpecified = false;

            if (Enum.TryParse(input, true, out SortType sortType))
            {
                if (sortType != SortType.NotSpecified)
                {
                    isSpecified = true;
                }
            }

            return isSpecified;
        }
    }
}