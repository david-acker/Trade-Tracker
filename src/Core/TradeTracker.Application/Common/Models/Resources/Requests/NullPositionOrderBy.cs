using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Interfaces.Resources.Requests;

namespace TradeTracker.Application.Common.Models.Resources.Requests
{
    public class NullPositionOrderBy : IPositionOrderBy
    {
        public string Field { get; set; } = "quantity";
        public SortType Type { get; set; } = SortType.Descending;     
    }
}