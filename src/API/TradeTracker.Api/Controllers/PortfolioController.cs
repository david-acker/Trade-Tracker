using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeTracker.Application.Features.Portfolio.Queries.GetCurrentHoldings;

namespace TradeTracker.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : Controller
    {
        private readonly IMediator _mediator;

        public PortfolioController(IMediator mediator)
        {
            _mediator = mediator 
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("current", Name = "GetCurrentHoldings")]
        public async Task<ActionResult<IEnumerable<HoldingVm>>> GetCurrentHoldings()
        {
            var query = new GetCurrentHoldingsQuery()
            {
                AccessKey = User.FindFirstValue("AccessKey"),
            };

            return Ok(await _mediator.Send(query));
        }

    }
}