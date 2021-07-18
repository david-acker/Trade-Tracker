using System;

namespace TradeTracker.Business.Services
{
    public interface IDateTimeService
    {
        bool HasDateTimeAlreadyOccurred(DateTime input);
    }

    public class DateTimeService : IDateTimeService
    {
        public DateTimeService()
        {
        }

        public bool HasDateTimeAlreadyOccurred(DateTime input)
        {
            return input <= DateTime.UtcNow;
        }
    }
}
