using System;
using System.Collections.Generic;

namespace TradeTracker.Application.UnitTests.Helpers.TestData
{
    public enum TestEnum
    {
        NotSpecified,
        FirstValue,
        SecondValue,
        ThirdValue
    }

    public class EnumHelperTestData
    {
        public static IEnumerable<object[]> IsNotDefaultTestData
        {
            get
            {
                yield return new object[]
                {
                    TestEnum.NotSpecified
                        .ToString(), 
                    false
                };
                yield return new object[]
                {
                    TestEnum.FirstValue
                        .ToString(), 
                    true
                };
                yield return new object[]
                {
                    TestEnum.FirstValue
                        .ToString()
                        .ToLower(), 
                    true
                };
                yield return new object[]
                {
                    TestEnum.FirstValue
                        .ToString()
                        .ToUpper(), 
                    true
                };
                yield return new object[]
                {
                    TestEnum.SecondValue
                        .ToString(), 
                    true
                };
                yield return new object[]
                {
                    TestEnum.ThirdValue
                        .ToString(), 
                    true
                };
                yield return new object[]
                {
                    String.Empty,
                    false
                };
                yield return new object[]
                {
                    "abc",
                    false
                };
                yield return new object[]
                {
                    "0",
                    false
                };
            }
        }

        public static IEnumerable<object[]> ToListTestData
        {
            get
            {
                yield return new object[]
                {
                    -1,
                    new List<string>() 
                    {
                        TestEnum.NotSpecified.ToString(),
                        TestEnum.FirstValue.ToString(),
                        TestEnum.SecondValue.ToString(),
                        TestEnum.ThirdValue.ToString(),
                    }
                };
                yield return new object[]
                {
                    null,
                    new List<string>() 
                    {
                        TestEnum.NotSpecified.ToString(),
                        TestEnum.FirstValue.ToString(),
                        TestEnum.SecondValue.ToString(),
                        TestEnum.ThirdValue.ToString(),
                    }
                };
                yield return new object[]
                {
                    0,
                    new List<string>() 
                    {
                        TestEnum.NotSpecified.ToString(),
                        TestEnum.FirstValue.ToString(),
                        TestEnum.SecondValue.ToString(),
                        TestEnum.ThirdValue.ToString(),
                    }
                };
                yield return new object[]
                {
                    1,
                    new List<string>() 
                    {
                        TestEnum.FirstValue.ToString(),
                        TestEnum.SecondValue.ToString(),
                        TestEnum.ThirdValue.ToString(),
                    }
                };
                yield return new object[]
                {
                    2,
                    new List<string>() 
                    {
                        TestEnum.SecondValue.ToString(),
                        TestEnum.ThirdValue.ToString(),
                    }
                };
                yield return new object[]
                {
                    3,
                    new List<string>() 
                    {
                        TestEnum.ThirdValue.ToString(),
                    }
                };
                yield return new object[]
                {
                    4,
                    new List<string>() 
                    {
                        TestEnum.NotSpecified.ToString(),
                        TestEnum.FirstValue.ToString(),
                        TestEnum.SecondValue.ToString(),
                        TestEnum.ThirdValue.ToString(),
                    }
                };
            }
        }

        public static IEnumerable<object[]> DisplayTestData
        {
            get
            {
                yield return new object[]
                {
                    -1,
                    null,
                    "NotSpecified, FirstValue, SecondValue, ThirdValue"
                };
                yield return new object[]
                {
                    null,
                    null,
                    "NotSpecified, FirstValue, SecondValue, ThirdValue"
                };
                yield return new object[]
                {
                    0,
                    null,
                    "NotSpecified, FirstValue, SecondValue, ThirdValue"
                };
                yield return new object[]
                {
                    1,
                    null,
                    "FirstValue, SecondValue, ThirdValue"
                };
                yield return new object[]
                {
                    2,
                    null,
                    "SecondValue, ThirdValue"
                };
                yield return new object[]
                {
                    3,
                    null,
                    "ThirdValue"
                };
                yield return new object[]
                {
                    4,
                    null,
                    "NotSpecified, FirstValue, SecondValue, ThirdValue"
                };
                yield return new object[]
                {
                    null,
                    " ",
                    "NotSpecified FirstValue SecondValue ThirdValue"
                };
                yield return new object[]
                {
                    null,
                    "-",
                    "NotSpecified-FirstValue-SecondValue-ThirdValue"
                };
                yield return new object[]
                {
                    2,
                    " - ",
                    "SecondValue - ThirdValue"
                };
            }
        }
    }
}
