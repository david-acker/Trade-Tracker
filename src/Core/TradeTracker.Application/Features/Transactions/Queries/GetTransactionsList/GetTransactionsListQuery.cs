using System;
using System.Collections.Generic;
using MediatR;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionsList
{
    public class GetTransactionsListQuery : IRequest<PagedTransactionsListVm>
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

        public DateTime StartRange { get; set; } = DateTime.MinValue; 
        public DateTime EndRange { get; set; } = DateTime.MaxValue;
    }
}
