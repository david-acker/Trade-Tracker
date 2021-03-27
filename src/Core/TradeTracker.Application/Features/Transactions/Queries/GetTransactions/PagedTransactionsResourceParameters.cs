using System;
using System.Collections.Generic;
using TradeTracker.Api.Models.Filtering;
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

        public Selection Selection { get; set; } 

        public DateTime RangeStart { get; set; }
        public DateTime RangeEnd { get; set; }
    }
}