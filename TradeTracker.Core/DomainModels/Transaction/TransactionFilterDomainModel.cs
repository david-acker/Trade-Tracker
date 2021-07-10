using System;

namespace TradeTracker.Core.DomainModels.Transaction
{
    public class TransactionFilterDomainModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Symbol { get; set; }
        public char? TransactionType { get; set; }
        public string OrderByField { get; set; }
        public char? OrderByDirection { get; set; }
    }
}
