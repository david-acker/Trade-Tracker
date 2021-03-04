using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeTracker.Application.Features.Securities.Queries.GetSecurityOverview;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransaction;

namespace TradeTracker.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SecuritiesController : Controller
    {
        private readonly IMediator _mediator;

        public SecuritiesController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator 
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{symbol}", Name = "GetSecurityOverviewBySymbol")]
        public async Task<ActionResult<SecurityOverviewDto>> GetSecurityOverviewBySymbol(string symbol)
        {
            var query = new GetSecurityOverviewQuery()
            {
                AccessKey = User.FindFirstValue("AccessKey"),
                Symbol = symbol
            };
            
            return Ok(await _mediator.Send(query));
        }
    }
}