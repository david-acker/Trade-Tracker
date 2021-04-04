using System;
using System.Collections.Generic;

namespace TradeTracker.Application.UnitTests.Helpers.TestData
{
    public class DateTimeRangeHelperTestData
    {
        public static IEnumerable<object[]> IsValidDateTimeTestData
        {
            get
            {
                yield return new object[]
                {
                    "08/18/2018",
                    true
                };
                yield return new object[]
                {
                    "08/18/2018 07:22:16",
                    true
                };
                yield return new object[]
                {
                    "2018-08-18T07:22:16.0000000Z",
                    true
                };
                yield return new object[]
                {
                    "",
                    false
                };
                yield return new object[]
                {
                    "13/32/0",
                    false
                };
                yield return new object[]
                {
                    "abc",
                    false
                };
            }
        }

        public static IEnumerable<object[]> IsStartBeforeEndTestData
        {
            get
            {
                yield return new object[]
                {
                    "06/01/2015",
                    "06/01/2020",
                    true
                };
                yield return new object[]
                {
                    "01/01/2020 01:00:00",
                    "01/01/2020 02:00:00",
                    true
                };
                yield return new object[]
                {
                    "06/01/2020",
                    "06/01/2015",
                    false
                };
                yield return new object[]
                {
                    "01/01/2020 03:00:00",
                    "01/01/2020 02:00:00",
                    false
                };
                yield return new object[]
                {
                    "01/01/2020 03:00:00",
                    "01/01/2020 03:00:00",
                    false
                };
                yield return new object[]
                {
                    "",
                    "",
                    false
                };
                yield return new object[]
                {
                    "abc",
                    "abc",
                    false
                };
                yield return new object[]
                {
                    "",
                    "01/01/2020 02:00:00",
                    false
                };
                yield return new object[]
                {
                    "abc",
                    "01/01/2020 02:00:00",
                    false
                };
                yield return new object[]
                {
                    "01/01/2020 03:00:00",
                    "",
                    false
                };
                yield return new object[]
                {
                    "01/01/2020 03:00:00",
                    "abc",
                    false
                };
            }
        }

        public static IEnumerable<object[]> IsNotDefaultTestData
        {
            get
            {
                yield return new object[]
                {
                   "01/01/2020 03:00:00",
                   true, 
                };
                yield return new object[]
                {
                   "01/01/2020",
                   true, 
                };
                yield return new object[]
                {
                   DateTime.MinValue.ToString(),
                   false, 
                };
                yield return new object[]
                {
                   "",
                   false, 
                };
                yield return new object[]
                {
                   "abc",
                   false, 
                };
                yield return new object[]
                {
                   "13/32/0",
                   false, 
                };
            }
        }
    }
}