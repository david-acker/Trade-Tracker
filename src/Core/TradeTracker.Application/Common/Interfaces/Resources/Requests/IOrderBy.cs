using TradeTracker.Application.Common.Enums;

namespace TradeTracker.Application.Interfaces.Resources.Requests
{
    public interface IOrderBy
    {
        string Field { get; set; }
        SortType Type { get; set; }   
    }
}