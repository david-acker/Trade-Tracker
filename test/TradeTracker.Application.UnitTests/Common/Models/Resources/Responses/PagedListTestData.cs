using System;
using System.Collections.Generic;
using System.Linq;

namespace TradeTracker.Application.UnitTests.Common.Models.Resources.Responses
{
    public class ExpectedPagedListRepresentation<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public List<T> Items { get; set; }
    }

    public class PagedListTestTestData
    {
        private static List<string> CreateTestDataList(int elementCount, string fillValue = "")
        {
            var array = new string[elementCount];

            Array.Fill(array, fillValue);
            
            return array.ToList();
        }

        public static IEnumerable<object[]> CreateFromListData
        {
            get
            {
                yield return new object[]
                {
                    CreateTestDataList(100),
                    0,
                    10,
                    new ExpectedPagedListRepresentation<string>()
                    {
                        CurrentPage = 1,
                        TotalPages = 10,
                        PageSize = 10,
                        TotalCount = 100,
                        HasPrevious = false,
                        HasNext = true,
                        Items = CreateTestDataList(10)
                    }
                };
                yield return new object[]
                {
                    CreateTestDataList(100),
                    1,
                    0,
                    new ExpectedPagedListRepresentation<string>()
                    {
                        CurrentPage = 1,
                        TotalPages = 100,
                        PageSize = 1,
                        TotalCount = 100,
                        HasPrevious = false,
                        HasNext = true,
                        Items = CreateTestDataList(1)
                    }
                };
            }
        }
    }
}
