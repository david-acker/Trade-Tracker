using System;

namespace TradeTracker.Application.Features.Transactions.Helpers
{
    public static class DateTimeRangeHelper
    {
        public static bool IsValidDateTime(string input)
        {
            return DateTime.TryParse(input, out _);
        }

        public static bool IsStartBeforeEnd(string startInput, string endInput)
        {
            var isValidStart = DateTime.TryParse(startInput, out DateTime start);
            var isValidEnd = DateTime.TryParse(endInput, out DateTime end);

            if (isValidStart && isValidEnd)
            {
                return (start < end);
            }
            else
            {
                return false;
            }
        }

        public static bool IsNotDefault(string input)
        {
            var isValid = DateTime.TryParse(input, out DateTime dateTime);

            if (isValid)
            {
                return !dateTime.Equals(DateTime.MinValue)
                    && !dateTime.Equals(DateTime.MaxValue);
            }
            else
            {
                return false;
            }
        }
    }
}