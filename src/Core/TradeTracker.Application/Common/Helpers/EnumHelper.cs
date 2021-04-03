using System;

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
    }
}