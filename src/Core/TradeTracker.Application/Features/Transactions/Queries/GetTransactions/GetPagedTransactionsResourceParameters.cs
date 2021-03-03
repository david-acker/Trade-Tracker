using System;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetPagedTransactionsResourceParameters
    {
        public string AccessKey { get; set; }

        public string OrderBy { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public List<string> Including { get; set; }
        public List<string> Excluding { get; set; }

        public DateTime RangeStart { get; set; }
        public DateTime RangeEnd { get; set; }
    }
}