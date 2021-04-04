using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Common.Helpers;
using TradeTracker.Application.Interfaces.Resources.Requests;

namespace TradeTracker.Application.Common.Models.Resources.Requests
{
    public class TransactionOrderBy : ITransactionOrderBy
    {
        public string Field { get; set; } = "DateTime";
        public SortType Type { get; set; } = SortType.Descending;

        public TransactionOrderBy() { }
        public TransactionOrderBy(string orderByString)
        {
            Field = OrderByParser.ExtractField(orderByString);
            Type = OrderByParser.ExtractSortType(orderByString);
        }    
    }
}