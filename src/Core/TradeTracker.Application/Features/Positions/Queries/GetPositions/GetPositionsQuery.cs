using MediatR;
using System;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQuery : IRequest<PagedPositionsBaseDto>
    {
        public Guid AccessKey { get; set; }

        public List<string> Fields { get; set; }

        public string OrderBy { get; set; } = "Quantity";

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

        public List<string> Including { get; set; }
        public List<string> Excluding { get; set; }

        public string Exposure { get; set; }
    }
}
