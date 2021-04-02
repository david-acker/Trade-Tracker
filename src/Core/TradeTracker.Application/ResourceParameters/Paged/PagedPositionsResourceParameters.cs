using TradeTracker.Api.Models.Querying;

namespace TradeTracker.Application.ResourceParameters.Paged
{
    public class PagedPositionsResourceParameters : IPagedResourceParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public SortOrder SortOrder { get; set; }
        public Selection Selection { get; set; }
        public string Exposure { get; set; }
    }
}