using System;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetPagedTransactionsResourceParameters
    {
        public string Order { get; set; } = "DateTime+desc";

        private string _type = "";
        public string Type
        {
            get => _type;
            set => _type = value.ToLower();
        }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 25;

        public string Selection { get; set; }

        public string RangeStart { get; set; }
        public string RangeEnd { get; set; }
    }
}