using System;
using System.Collections.Generic;
using System.Linq;

namespace TradeTracker.Application.Common.Helpers
{
    public static class EnumHelper
    {
        public static bool IsNotDefault<TEnum>(string input)
            where TEnum : struct, Enum
        {
            var isSpecified = false;

            if (Enum.TryParse(input.Trim(), true, out TEnum enumType))
            {
                if (!enumType.Equals(default(TEnum)))
                {
                    isSpecified = true;
                }
            }

            return isSpecified;
        }

        public static List<string> ToList<TEnum>(
            int startIndex = 0)
            where TEnum : struct, Enum
        {
            var names = Enum.GetNames(typeof(TEnum)).ToList();

            if (startIndex < 0 || startIndex >= names.Count()) { startIndex = 0; }

            var count = names.Count() - startIndex;

            return names.GetRange(startIndex, count);
        }

        public static string Display<TEnum>(
            int startIndex = 0,
            string separator = ", ")
            where TEnum : struct, Enum
        {
            var names = EnumHelper.ToList<TEnum>(startIndex);
            
            if (separator == null) { separator = ", "; }

            return String.Join(separator, names);
        }
    }
}