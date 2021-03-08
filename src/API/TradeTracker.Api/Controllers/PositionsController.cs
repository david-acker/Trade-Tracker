using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeTracker.Application.Features.Positions;
using TradeTracker.Application.Features.Positions.Queries.GetPosition;
using TradeTracker.Application.Features.Positions.Queries.GetPositions;

namespace TradeTracker.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PositionsController : Controller
    {
        private readonly ILogger<PositionsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PositionsController(
            IMapper mapper, 
            IMediator mediator,
            ILogger<PositionsController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetPositions")]
        public async Task<ActionResult<IEnumerable<PositionForReturnDto>>> GetPositions()
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPositions)} was called.");

            var query = new GetPositionsQuery()
            {
                AccessKey = Guid.Parse(User.FindFirstValue("AccessKey"))
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpOptions(Name = "OptionsForPositions")]
        public IActionResult OptionsForPositions()
        {
            _logger.LogInformation($"PositionsController: {nameof(OptionsForPositions)} was called.");

            Response.Headers.Add("Allow", "GET,OPTIONS");
            
            return NoContent();
        }

        [HttpGet("{symbol}", Name = "GetPosition")]
        public async Task<ActionResult<PositionForReturnDto>> GetPosition([FromRoute] string symbol)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPosition)} was called.");

            var query = new GetPositionQuery()
            {
                AccessKey = Guid.Parse(User.FindFirstValue("AccessKey")),
                Symbol = symbol
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpOptions("{symbol}", Name = "OptionsForPositionBySymbol")]
        public IActionResult OptionsForPositionBySymbol()
        {
            _logger.LogInformation($"PositionsController: {nameof(OptionsForPositionBySymbol)} was called.");

            Response.Headers.Add("Allow", "GET,OPTIONS");
            
            return NoContent();
        }
    }
}