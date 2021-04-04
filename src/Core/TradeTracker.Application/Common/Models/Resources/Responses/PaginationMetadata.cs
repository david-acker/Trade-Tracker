namespace TradeTracker.Application.Common.Models.Resources.Responses
{
    public class PaginationMetadata
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int TotalRecordCount { get; set; }
    }
}