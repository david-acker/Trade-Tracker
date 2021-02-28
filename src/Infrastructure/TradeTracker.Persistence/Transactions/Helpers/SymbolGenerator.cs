using System;
using System.Linq;

namespace TradeTracker.Persistence.Seed.Transactions.Helpers
{
    public static class SymbolGenerator
    {
        public static string GenerateEquitySymbol(Random random, int maximumLength)
        {
            const string characterSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            
            int symbolLength = random.Next(maximumLength) + 1;

            return new string(Enumerable.Repeat(characterSet, symbolLength)
                .Select(c => c[random.Next(c.Length)]).ToArray());
        }
    }
}