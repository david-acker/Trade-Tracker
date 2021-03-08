using System;

namespace TradeTracker.Persistence.Seed.Transactions.Helpers
{
    public static class DecimalGenerator
    {
        public static decimal GenerateInRange(Random random, decimal minimumValue, decimal maximumValue)
        {
            var range = (int)((maximumValue - minimumValue) * 100);
            
            return minimumValue + ((decimal)random.Next(range) / 100);
        }
    }
}