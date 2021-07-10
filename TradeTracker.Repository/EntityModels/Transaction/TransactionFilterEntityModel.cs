using System;

namespace TradeTracker.Repository.EntityModels.Transaction
{
    public class TransactionFilterEntityModel : BaseFilterEntityModel
    {
        public string AccessKey { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Symbol { get; set; }
        public char? TransactionType { get; set; }
        public string OrderByField { get; set; }
        public char? OrderByDirection { get; set; }
    }
}
