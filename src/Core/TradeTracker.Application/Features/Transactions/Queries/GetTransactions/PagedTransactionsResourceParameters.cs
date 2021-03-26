using System;
using System.Collections.Generic;
using TradeTracker.Application.Enums;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class PagedTransactionsResourceParameters
    {
        public Guid AccessKey { get; set; }

        public string OrderBy { get; set; }
        public SortOrder SortOrder { get; set; }

        public string Type { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public List<string> Selection { get; set; }
        public SelectionType SelectionType { get; set; }

        public DateTime RangeStart { get; set; }
        public DateTime RangeEnd { get; set; }
    }
}