using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Api.ActionConstraints;
using TradeTracker.Api.Helpers;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Application.Features.Positions;
using TradeTracker.Application.Features.Positions.Queries.GetPosition;
using TradeTracker.Application.Features.Positions.Queries.GetPositions;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Api.Controllers
{
    #pragma warning disable CS1591

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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


        /// <summary>
        /// Get a paged list of positions.
        /// </summary>
        /// <param name="query">The resource parameters for specifying the returned positions</param>
        /// <remarks>
        /// Example: \
        /// GET /api/positions \
        /// { \
        ///     "orderBy": "Quantity", \
        ///     "pageNumber": "3" \
        ///     "pageSize": "25", \
        ///     "excluding": [ \
        ///         "QRS", \
        ///         "TUV", \
        ///         "WXY" \
        ///     ], \
        ///     "Exposure": "Long", \
        /// } 
        /// </remarks>
        /// <response code="200">Returns any paged positions matching the parameters</response>
        /// <response code="422">Validation Error</response>
        [HttpGet(Name = "GetPositions")]
        [Consumes("application/json")]
        [Produces("application/json",
            "application/vnd.trade.pagedpositions+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/json",
            "application/vnd.trade.pagedpositions+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<IEnumerable<PositionForReturn>>> GetPositions(
            [FromQuery] GetPositionsQuery query)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPositions)} was called.");

            var pagedPositionsBase = await _mediator.Send(query);

            Response.Headers.Add("X-Paging-PageNumber", pagedPositionsBase.CurrentPage.ToString());
            Response.Headers.Add("X-Paging-PageSize", pagedPositionsBase.PageSize.ToString());
            Response.Headers.Add("X-Paging-PageCount", pagedPositionsBase.TotalPages.ToString());
            Response.Headers.Add("X-Paging-TotalRecordCount", pagedPositionsBase.TotalCount.ToString());

            return Ok(pagedPositionsBase.Items);
        }
        

        /// <summary>
        /// Get a paged list of positions.
        /// </summary>
        /// <param name="query">The resource parameters for specifying the returned positions</param>
        /// <remarks>
        /// Example: \
        /// GET /api/positions \
        /// { \
        ///     "orderBy": "Quantity", \
        ///     "pageNumber": "3" \
        ///     "pageSize": "25", \
        ///     "excluding": [ \
        ///         "QRS", \
        ///         "TUV", \
        ///         "WXY" \
        ///     ], \
        ///     "Exposure": "Long", \
        /// } 
        /// </remarks>
        /// <response code="200">Returns any paged positions matching the parameters</response>
        /// <response code="422">Validation Error</response>
        [HttpGet(Name = "GetPositions")]
        [Consumes("application/json")]
        [Produces("application/vnd.trade.pagedpositions.hateoas+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/vnd.trade.pagedpositions.hateoas+json")]
        public async Task<ActionResult<PagedPositionsWithLinks>> GetPositionsWithLinks(
            [FromQuery] GetPositionsQuery query)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPositionsWithLinks)} was called.");

            var pagedPositionsBase = await _mediator.Send(query);

            var pagedPositionsWithLinks = new PagedPositionsWithLinks();

            pagedPositionsWithLinks.Items = _mapper
                .Map<IEnumerable<PositionForReturnWithLinks>>(pagedPositionsBase.Items);

            pagedPositionsWithLinks.Items = pagedPositionsWithLinks.Items
                .Select(position => 
                {
                    position.Links = CreateLinksForPosition(position.Symbol);
                    return position;
                });
            
            pagedPositionsWithLinks.Links = 
                CreateLinksForPositions(
                    query,
                    pagedPositionsBase.HasNext,
                    pagedPositionsBase.HasPrevious);

            pagedPositionsWithLinks.Metadata = 
                new PaginationMetadata()
                {
                    PageNumber = pagedPositionsBase.CurrentPage,
                    PageSize = pagedPositionsBase.PageSize,
                    PageCount = pagedPositionsBase.TotalPages,
                    TotalRecordCount = pagedPositionsBase.TotalCount
                };

            return Ok(pagedPositionsWithLinks);
        }


        /// <summary>
        /// Options for /api/positions URI.
        /// </summary>
        /// <remarks>
        /// Example: \
        /// OPTIONS /api/positions 
        /// </remarks>
        [HttpOptions(Name = "OptionsForPositions")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForPositions()
        {
            _logger.LogInformation($"PositionsController: {nameof(OptionsForPositions)} was called.");

            Response.Headers.Add("Allow", "GET,OPTIONS");
            
            return NoContent();
        }


        /// <summary>
        /// Gets a position by symbol of its security.
        /// </summary>
        /// <param name="symbol">The symbol for the position</param>
        /// <remarks>
        /// Example: \
        /// GET /api/positions/{symbol} 
        /// </remarks>
        /// <response code="200">Returns the requested position</response>
        /// <response code="422">Validation Error</response>
        [HttpGet("{symbol}", Name = "GetPosition")]
        [Produces("application/json", 
            "application/vnd.trade.position+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/json",
            "application/vnd.trade.position+json")]
        public async Task<ActionResult<PositionForReturn>> GetPosition(
            [FromRoute] string symbol)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPosition)} was called.");

            var query = new GetPositionQuery() { Symbol = symbol };

            var position = await _mediator.Send(query);

            return Ok(position);
        }


        /// <summary>
        /// Gets a position by symbol of its security.
        /// </summary>
        /// <param name="symbol">The symbol for the position</param>
        /// <remarks>
        /// Example: \
        /// GET /api/positions/{symbol} 
        /// </remarks>
        /// <response code="200">Returns the requested position</response>
        /// <response code="422">Validation Error</response>
        [HttpGet("{symbol}", Name = "GetPositionWithLinks")]
        [Produces("application/vnd.trade.position.hateoas+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/vnd.trade.position.hateoas+json")]
        public async Task<ActionResult<PositionForReturnWithLinks>> GetPositionWithLinks(
            [FromRoute] string symbol)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPositionWithLinks)} was called.");

            var query = new GetPositionQuery() { Symbol = symbol };

            var position = await _mediator.Send(query);

            var positionWithLinks = _mapper.Map<PositionForReturnWithLinks>(position);

            positionWithLinks.Links = CreateLinksForPosition(symbol);

            return Ok(positionWithLinks);
        }


        /// <summary>
        /// Gets a position by symbol of its security.
        /// </summary>
        /// <param name="symbol">The symbol for the position</param>
        /// <remarks>
        /// Example: \
        /// GET /api/positions/{symbol} 
        /// </remarks>
        /// <response code="200">Returns the requested position</response>
        /// <response code="422">Validation Error</response>
        [HttpGet("{symbol}", Name = "GetDetailedPositionWithLinks")]
        [Produces("application/vnd.trade.detailedposition.hateoas+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.trade.detailedposition.hateoas+json")]
        public async Task<ActionResult<PositionForReturnWithLinks>> GetDetailedPositionWithLinks(
            [FromRoute] string symbol)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPositionWithLinks)} was called.");

            var query = new GetDetailedPositionQuery() { Symbol = symbol };

            var detailedPosition = await _mediator.Send(query);

            var detailedPositionWithLinks = 
                _mapper.Map<DetailedPositionForReturnWithLinks>(detailedPosition);

            detailedPositionWithLinks.SourceRelations =
                detailedPositionWithLinks.SourceRelations
                    .Select(fullSourceLink => 
                    {
                        fullSourceLink.Transaction.Links = 
                            CreateLinksForTransaction(fullSourceLink.Transaction.Id);

                        return fullSourceLink;

                    }).ToList();

            detailedPositionWithLinks.Links = CreateLinksForPosition(symbol);

            return Ok(detailedPositionWithLinks);
        }


        /// <summary>
        /// Options for /api/positions/{symbol} URI.
        /// </summary>
        /// <remarks>
        /// Example: \
        /// OPTIONS /api/positions/{symbol} 
        /// </remarks>
        [HttpOptions("{symbol}", Name = "OptionsForPositionBySymbol")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForPositionBySymbol()
        {
            _logger.LogInformation($"PositionsController: {nameof(OptionsForPositionBySymbol)} was called.");

            Response.Headers.Add("Allow", "GET,OPTIONS");
            
            return NoContent();
        }


        private IEnumerable<Link> CreateLinksForPosition(string symbol)
        {
            var links = new List<Link>()
            {
                new Link(
                    Url.Link(
                        "GetPosition", 
                        new { symbol }),
                    "self",
                    "GET")
            };
                    
            return links;
        }


        private IEnumerable<Link> CreateLinksForPositions(
            GetPositionsQuery query,
            bool hasNext,
            bool hasPrevious)
        {
            var links = new List<Link>();

            links.Add(
                new Link(
                    CreatePositionsResourceUrl(
                        query, 
                        ResourceUriType.CurrentPage),
                    "self",
                    "GET"));

            if (hasNext)
            {
                links.Add(
                    new Link(
                        CreatePositionsResourceUrl(
                            query, 
                            ResourceUriType.NextPage),
                        "nextPage",
                        "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new Link(
                        CreatePositionsResourceUrl(
                            query, 
                            ResourceUriType.PreviousPage),
                        "previousPage",
                        "GET"));
            }

            return links;
        }


        private string CreatePositionsResourceUrl(
            GetPositionsQuery query,
            ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link(
                        "GetPositions",
                        new
                        {
                            orderBy = query.OrderBy,
                            pageNumber = query.PageNumber - 1,
                            pageSize = query.PageSize,
                            symbolSelection = query.SymbolSelection,
                            exposureType = query.ExposureType
                        });

                case ResourceUriType.NextPage:
                    return Url.Link(
                        "GetPositions",
                        new
                        {
                            orderBy = query.OrderBy,
                            pageNumber = query.PageNumber + 1,
                            pageSize = query.PageSize,
                            symbolSelection = query.SymbolSelection,
                            exposureType = query.ExposureType
                        });

                case ResourceUriType.CurrentPage:
                default:
                    return Url.Link(
                        "GetPositions",
                        new
                        {
                            orderBy = query.OrderBy,
                            pageNumber = query.PageNumber,
                            pageSize = query.PageSize,
                            symbolSelection = query.SymbolSelection,
                            exposureType = query.ExposureType
                        });
            }
        }

        private IEnumerable<Link> CreateLinksForTransaction(
            Guid transactionId)
        {
            var links = new List<Link>();

            links.Add(
                new Link(
                    Url.Link(
                        "GetTransaction", 
                        new { transactionId }),
                "self",
                "GET"));

            links.Add(
                new Link(
                    Url.Link(
                        "UpdateTransaction",
                        new { transactionId }),
                    "update transaction",
                    "PUT"));
                
            links.Add(
                new Link(
                    Url.Link(
                        "PatchTransaction",
                        new { transactionId }),
                    "patch transaction",
                    "PATCH"));

            links.Add(
                new Link(
                    Url.Link(
                        "DeleteTransaction",
                        new { transactionId }),
                    "delete transaction",
                    "DELETE"));

            return links;
        }
    }
    
    #pragma warning restore CS1591
}