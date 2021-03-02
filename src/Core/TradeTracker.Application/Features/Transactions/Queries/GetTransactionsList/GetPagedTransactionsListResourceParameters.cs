using System;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionsList
{
    public class GetPagedTransactionsListResourceParameters
    {
        public string AccessKey { get; set; }

        public string OrderBy { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public List<string> Including { get; set; }
        public List<string> Excluding { get; set; }

        public DateTime StartRange { get; set; }
        public DateTime EndRange { get; set; }
    }
}