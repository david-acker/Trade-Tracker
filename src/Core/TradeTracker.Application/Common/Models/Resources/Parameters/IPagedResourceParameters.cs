namespace TradeTracker.Application.ResourceParameters
{
    public interface IPagedResourceParameters
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}