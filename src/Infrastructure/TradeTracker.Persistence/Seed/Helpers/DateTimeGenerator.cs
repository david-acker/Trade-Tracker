using System;

namespace TradeTracker.Persistence.Seed.Transactions.Helpers
{
    public static class DateTimeGenerator
    {
        public static DateTime GenerateOpenMarketDateTime(Random random, DateTime start)
        {
            DateTime dateComponent;

            // NYSE Market Open (14:30 UTC)
            int openMinuteTime = 870;
            // NYSE Market Close (21:00 UTC)
            int closeMinuteTime = 1260;

            int dayRange = (DateTime.UtcNow.Date - start).Days;

            while (true)
            {
                dateComponent = start.AddDays(random.Next(dayRange));

                var dayOfWeek = (int)dateComponent.DayOfWeek;
                if (dayOfWeek > 0 && dayOfWeek < 6)
                {
                    break;
                }
            }

            int timeComponent = openMinuteTime + random.Next(closeMinuteTime - openMinuteTime);

            return dateComponent.AddMinutes(timeComponent);
        }
    }
}