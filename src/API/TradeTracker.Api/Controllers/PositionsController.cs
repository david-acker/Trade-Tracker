using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeTracker.Api.Helpers;
using TradeTracker.Application.Features.Positions;
using TradeTracker.Application.Features.Positions.Queries.GetPosition;
using TradeTracker.Application.Features.Positions.Queries.GetPositions;
using TradeTracker.Application.Models.Navigation;

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
        [Produces("application/json",
            "application/vnd.trade.hateoas+json")]
        public async Task<ActionResult<IEnumerable<PositionForReturnDto>>> GetPositions(
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPositions)} was called.");


            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }


            var query = new GetPositionsQuery()
            {
                AccessKey = Guid.Parse(User.FindFirstValue("AccessKey"))
            };

            var positions = await _mediator.Send(query);

            var positionsToReturn = positions.ShapeData(null);

            var includeLinks = parsedMediaType.SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);

            if (includeLinks)
            {
                var linkedPositionsToReturn = positionsToReturn
                    .Select(position =>
                    {
                       var positionAsDictionary = position as IDictionary<string, object>;

                       var positionLinks = CreateLinksForPosition(
                            (string)positionAsDictionary["Symbol"]);
                    
                       positionAsDictionary.Add("links", positionLinks);
                       return positionAsDictionary;
                    });;

                return Ok(linkedPositionsToReturn);
            }
            else
            {
                return Ok(positionsToReturn);
            }
        }

        [HttpOptions(Name = "OptionsForPositions")]
        public IActionResult OptionsForPositions()
        {
            _logger.LogInformation($"PositionsController: {nameof(OptionsForPositions)} was called.");

            Response.Headers.Add("Allow", "GET,OPTIONS");
            
            return NoContent();
        }

        [HttpGet("{symbol}", Name = "GetPosition")]
        [Produces("application/json",
            "application/vnd.trade.hateoas+json")]
        public async Task<ActionResult<PositionForReturnDto>> GetPosition(
            [FromRoute] string symbol,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPosition)} was called.");

            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }

            var query = new GetPositionQuery()
            {
                AccessKey = Guid.Parse(User.FindFirstValue("AccessKey")),
                Symbol = symbol
            };

            var position = await _mediator.Send(query);

            var positionToReturn = position.ShapeData(null) as IDictionary<string, object>;

            var includeLinks = parsedMediaType.SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);

            if (includeLinks)
            {
                var links = CreateLinksForPosition(symbol);

                positionToReturn.Add("links", links);
            }

            return Ok(positionToReturn);
        }

        [HttpOptions("{symbol}", Name = "OptionsForPositionBySymbol")]
        public IActionResult OptionsForPositionBySymbol()
        {
            _logger.LogInformation($"PositionsController: {nameof(OptionsForPositionBySymbol)} was called.");

            Response.Headers.Add("Allow", "GET,OPTIONS");
            
            return NoContent();
        }

        private IEnumerable<LinkDto> CreateLinksForPosition(string symbol)
        {
            var links = new List<LinkDto>()
            {
                new LinkDto(
                    Url.Link(
                        "GetPosition", 
                        new { symbol }),
                    "self",
                    "GET")
            };
                    
            return links;
        }
    }
}