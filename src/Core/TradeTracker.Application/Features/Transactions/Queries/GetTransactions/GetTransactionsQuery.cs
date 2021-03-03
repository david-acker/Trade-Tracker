using System;
using System.Collections.Generic;
using MediatR;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQuery : IRequest<PagedTransactionsDto>
    {
        public string AccessKey { get; set; }

        public string OrderBy { get; set; } = "DateTime";

        private int _pageNumber = 1;
        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value < 1) ? 1 : value;
        }
        const int MaxPageSize = 100;
        
        private int _pageSize = 25;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public List<string> Including { get; set; }
        public List<string> Excluding { get; set; }

        public DateTime RangeStart { get; set; } = DateTime.MinValue; 
        public DateTime RangeEnd { get; set; } = DateTime.MaxValue;
    }
}
