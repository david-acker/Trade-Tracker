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
        public async Task<IActionResult> GetPositions(
            [FromQuery] GetPositionsResourceParameters parameters,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPositions)} was called.");

            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }

            var query = _mapper.Map<GetPositionsQuery>(parameters);
            query.AccessKey = Guid.Parse(User.FindFirstValue("AccessKey"));

            var pagedPositions = await _mediator.Send(query);

            var positionsToReturn = pagedPositions.Items.ShapeData(null);

            var includeLinks = parsedMediaType.SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);

            if (includeLinks)
            {
                var links = CreateLinksForPositions(
                    parameters,
                    pagedPositions.HasNext,
                    pagedPositions.HasPrevious);

                var linkedPositionsToReturn = positionsToReturn
                    .Select(position =>
                    {
                       var positionAsDictionary = position as IDictionary<string, object>;

                       var positionLinks = CreateLinksForPosition(
                            (string)positionAsDictionary["Symbol"]);
                    
                       positionAsDictionary.Add("links", positionLinks);
                       return positionAsDictionary;
                    });;

                var paginationMetadata = new
                {
                    pageNumber = pagedPositions.CurrentPage,
                    pageSize = pagedPositions.PageSize,
                    pageCount = pagedPositions.TotalPages,
                    totalRecordCount = pagedPositions.TotalCount,
                };

                var linkedPositionsResource = new
                {
                    paginationMetadata = paginationMetadata,
                    results = linkedPositionsToReturn,
                    links
                };

                return Ok(linkedPositionsResource);
            }
            else
            {
                Response.Headers.Add("X-Paging-PageNumber", pagedPositions.CurrentPage.ToString());
                Response.Headers.Add("X-Paging-PageSize", pagedPositions.PageSize.ToString());
                Response.Headers.Add("X-Paging-PageCount", pagedPositions.TotalPages.ToString());
                Response.Headers.Add("X-Paging-TotalRecordCount", pagedPositions.TotalCount.ToString());

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
        public async Task<IActionResult> GetPosition(
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

        private IEnumerable<LinkDto> CreateLinksForPositions(
            GetPositionsResourceParameters parameters,
            bool hasNext,
            bool hasPrevious)
        {
            var links = new List<LinkDto>();

            links.Add(
                new LinkDto(
                    CreatePositionsResourceUrl(
                        parameters, 
                        ResourceUriType.CurrentPage),
                    "self",
                    "GET"));

            if (hasNext)
            {
                links.Add(
                    new LinkDto(
                        CreatePositionsResourceUrl(
                            parameters, 
                            ResourceUriType.NextPage),
                        "nextPage",
                        "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreatePositionsResourceUrl(
                            parameters, 
                            ResourceUriType.PreviousPage),
                        "previousPage",
                        "GET"));
            }

            return links;
        }

        private string CreatePositionsResourceUrl(
            GetPositionsResourceParameters parameters,
            ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link(
                        "GetPositions",
                        new
                        {
                            orderBy = parameters.OrderBy,
                            pageNumber = parameters.PageNumber - 1,
                            pageSize = parameters.PageSize,
                            including = parameters.Including,
                            excluding = parameters.Excluding,
                            exposure = parameters.Exposure
                        });

                case ResourceUriType.NextPage:
                    return Url.Link(
                        "GetPositions",
                        new
                        {
                            orderBy = parameters.OrderBy,
                            pageNumber = parameters.PageNumber + 1,
                            pageSize = parameters.PageSize,
                            including = parameters.Including,
                            excluding = parameters.Excluding,
                            exposure = parameters.Exposure
                        });

                case ResourceUriType.CurrentPage:
                default:
                    return Url.Link(
                        "GetPositions",
                        new
                        {
                            orderBy = parameters.OrderBy,
                            pageNumber = parameters.PageNumber,
                            pageSize = parameters.PageSize,
                            including = parameters.Including,
                            excluding = parameters.Excluding,
                            exposure = parameters.Exposure
                        });
            }
        }
    }
}