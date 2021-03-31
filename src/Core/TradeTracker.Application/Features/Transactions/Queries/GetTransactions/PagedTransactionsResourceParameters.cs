using System;
using TradeTracker.Api.Models.Querying;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class PagedTransactionsResourceParameters
    {
        public SortOrder SortOrder { get; set; }

        public string Type { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public Selection Selection { get; set; } 

        public DateTime RangeStart { get; set; }
        public DateTime RangeEnd { get; set; }
    }
}