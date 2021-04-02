using System;
using TradeTracker.Api.Models.Querying;

namespace TradeTracker.Application.ResourceParameters.Paged
{
    public class PagedTransactionsResourceParameters : IPagedResourceParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public SortOrder SortOrder { get; set; }
        public string Type { get; set; }
        public Selection Selection { get; set; } 
        public DateTime RangeStart { get; set; }
        public DateTime RangeEnd { get; set; }
    }
}