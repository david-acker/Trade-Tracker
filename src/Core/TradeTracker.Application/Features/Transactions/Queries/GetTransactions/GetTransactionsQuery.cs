using System;
using System.Collections.Generic;
using MediatR;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQuery : IRequest<PagedTransactionsBaseDto>
    {
        public Guid AccessKey { get; set; }

        public string OrderBy { get; set; } = "DateTime";

        private int _pageNumber = 1;
        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value < 1) ? 1 : value;
        }

        const int MaxPageSize = 100;
        const int DefaultPageSize = 25;
    
        private int _pageSize = 25;
        public int PageSize
        {
            get => _pageSize;

            set
            {
                value = Math.Abs(value);
                
                switch (value)
                {
                    case var x when (value > MaxPageSize):
                        _pageSize = MaxPageSize;
                        break;
                    
                    case var x when (value < 1):
                        _pageSize = DefaultPageSize;
                        break;
                    
                    default:
                        _pageSize = value;
                        break;
                }
            }
        }

        public List<string> Including { get; set; }
        public List<string> Excluding { get; set; }

        public DateTime RangeStart { get; set; } = DateTime.MinValue; 
        public DateTime RangeEnd { get; set; } = DateTime.MaxValue;
    }
}
