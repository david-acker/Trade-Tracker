using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Interfaces.Resources.Requests;

namespace TradeTracker.Application.Common.Models.Resources.Requests
{
    public class NullTransactionOrderBy : ITransactionOrderBy
    {
        public string Field { get; set; } = "datetime";
        public SortType Type { get; set; } = SortType.Descending;     
    }
}