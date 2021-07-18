using System;

namespace TradeTracker.Api.DTOs.Transaction
{
    public class TransactionFilterDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 25;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Symbol { get; set; }
        public char? TransactionType { get; set; }
        public string OrderByField { get; set; }
        public char? OrderByDirection { get; set; }
    }
}
