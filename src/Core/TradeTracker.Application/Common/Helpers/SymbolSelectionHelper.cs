using System;
using TradeTracker.Application.Common.Enums;

namespace TradeTracker.Application.Common.Helpers
{
    public static class SymbolSelectionHelper
    {
        public static bool isSelectionTypeSpecified(string input)
        {
            var isSpecified = false;

            if (Enum.TryParse(input, true, out SelectionType selectionType))
            {
                if (selectionType != SelectionType.NotSpecified)
                {
                    isSpecified = true;
                }
            }

            return isSpecified;
        }
    }
}