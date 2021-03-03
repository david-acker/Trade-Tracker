using System;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsResourceParameters
    {
        public string OrderBy { get; set; } = "DateTime";

        private int _pageNumber = 1;
        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value < 1) ? 1 : value;
        }

        const int MaxPageSize = 100;
        const int DefaultPageSize = 25;
        
        private int _pageSize = DefaultPageSize;
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

        public string Including { get; set; }
        public string Excluding { get; set; }

        public string RangeStart { get; set; }
        public string RangeEnd { get; set; }
    }
}