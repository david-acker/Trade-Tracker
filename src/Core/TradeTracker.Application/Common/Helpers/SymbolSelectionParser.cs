using System;
using System.Collections.Generic;
using System.Linq;
using TradeTracker.Application.Common.Enums;

namespace TradeTracker.Application.Common.Helpers
{
    public static class SymbolSelectionParser
    {
        public static List<string> extractSymbols(
            string input,
            char selectionSeparator = ' ',
            char symbolSeparator = ',')
        {
            return input
                .Trim()
                .Split(selectionSeparator, StringSplitOptions.RemoveEmptyEntries)[0]
                .Split(symbolSeparator, StringSplitOptions.RemoveEmptyEntries)
                .Where(s => !String.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToList();
        }

        public static string extractSelectionTypeString(
            string input,
            char selectionSeparator = ' ')
        {
            return input
                .Trim()
                .Split(selectionSeparator, StringSplitOptions.RemoveEmptyEntries)[1]
                .Trim();
        }

        public static SelectionType extractSelectionType(
            string input,
            char selectionSeparator = ' ')
        {
            var selectionTypeString = extractSelectionTypeString(input, selectionSeparator);
        
            SelectionType selectionType = SelectionType.NotSpecified;
            Enum.TryParse(selectionTypeString, true, out selectionType);
        
            return selectionType;
        }

    }
}
