using System;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetPagedTransactionsResourceParameters
    {
        public string Order { get; set; } = "DateTime+desc";

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 25;

        public string Including { get; set; }
        public string Excluding { get; set; }

        public string RangeStart { get; set; }
        public string RangeEnd { get; set; }
    }
}