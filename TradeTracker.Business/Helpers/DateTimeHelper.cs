using System;

namespace TradeTracker.Business.Helpers
{
    public interface IDateTimeHelper
    {
        bool HasDateTimeAlreadyOccurred(DateTime input);
    }

    public class DateTimeHelper : IDateTimeHelper
    {
        public DateTimeHelper()
        {
        }

        public bool HasDateTimeAlreadyOccurred(DateTime input)
        {
            return input <= DateTime.UtcNow;
        }
    }
}
