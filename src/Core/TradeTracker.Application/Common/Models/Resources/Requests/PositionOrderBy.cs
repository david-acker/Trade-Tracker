using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Common.Helpers;
using TradeTracker.Application.Interfaces.Resources.Requests;

namespace TradeTracker.Application.Common.Models.Resources.Requests
{
    public class PositionOrderBy : IPositionOrderBy
    {
        public string Field { get; set; } = "quantity";
        public SortType Type { get; set; } = SortType.Descending;

        public PositionOrderBy() { }
        public PositionOrderBy(string orderByString)
        {
            Field = OrderByParser.ExtractField(orderByString).ToLower();
            Type = OrderByParser.ExtractSortType(orderByString);
        }    
    }
}