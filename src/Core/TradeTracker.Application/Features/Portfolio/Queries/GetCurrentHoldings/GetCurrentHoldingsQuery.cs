using MediatR;
using System;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Portfolio.Queries.GetCurrentHoldings
{
    public class GetCurrentHoldingsQuery : IRequest<IEnumerable<HoldingVm>>
    {
        public string AccessKey { get; set; }
    }
}
