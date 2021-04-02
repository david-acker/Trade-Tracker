namespace TradeTracker.Application.ResourceParameters.Paged
{
    public interface IPagedResourceParameters
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}