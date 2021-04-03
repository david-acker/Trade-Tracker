using System;
using System.Linq;

namespace TradeTracker.Application.Common.Helpers
{
    public static class StringHelper
    {
        public static bool ContainsNumberOfElementsAfterSplit(
            string input,
            int expectedCount,
            char separator = ' ')
        {
            var cleanedInput = input.Trim();

            var splitString = cleanedInput
                .Split(separator, System.StringSplitOptions.RemoveEmptyEntries)
                .Where(s => !String.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToList();
        
            return splitString.Count() == expectedCount; 
        }
    }
}