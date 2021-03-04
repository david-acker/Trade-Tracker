using MediatR;
using System;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Securities.Queries.GetSecurityOverview
{
    public class GetSecurityOverviewQuery :  IRequest<SecurityOverviewDto>
    {
        public string AccessKey { get; set; }
        public string Symbol { get; set; }
    }
}
