using System;
using TradeTracker.Api.Models.Querying;

namespace TradeTracker.Application.ResourceParameters.Unpaged
{
    public class UnpagedTransactionsResourceParameters : IUnpagedResourceParameters
    {
        public SortOrder SortOrder { get; set; }
        public string Type { get; set; }
        public Selection Selection { get; set; } 
        public DateTime RangeStart { get; set; }
        public DateTime RangeEnd { get; set; }
    }
}