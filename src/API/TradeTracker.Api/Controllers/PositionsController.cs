using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;
using TradeTracker.Api.ActionConstraints;
using TradeTracker.Api.Helpers;
using TradeTracker.Api.Models.Pagination;
using TradeTracker.Application.Features.Positions;
using TradeTracker.Application.Features.Positions.Queries.GetPosition;
using TradeTracker.Application.Features.Positions.Queries.GetPositions;
using TradeTracker.Application.Models.Navigation;

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
        [Produces("application/json", "application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [RequestHeaderMatchesMediaType("Accept", "application/json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<IEnumerable<PositionForReturnDto>>> GetPositions(
            [FromQuery] GetPositionsQuery query)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPositions)} was called.");

            var accessKey = Guid.Parse(User.FindFirstValue("AccessKey"));
            query.Authenticate(accessKey);

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
        [Produces("application/json", "application/vnd.trade.hateoas+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.trade.hateoas+json")]
        public async Task<ActionResult<PagedPositionsWithLinksDto>> GetPositionsWithLinks(
            [FromQuery] GetPositionsQuery query)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPositionsWithLinks)} was called.");

            var accessKey = Guid.Parse(User.FindFirstValue("AccessKey"));
            query.Authenticate(accessKey);

            var pagedPositionsBase = await _mediator.Send(query);

            var pagedPositionsWithLinks = new PagedPositionsWithLinksDto();

            pagedPositionsWithLinks.Items = _mapper
                .Map<IEnumerable<PositionForReturnWithLinksDto>>(pagedPositionsBase.Items);

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
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [RequestHeaderMatchesMediaType("Accept", "application/json")]
        public async Task<ActionResult<PositionForReturnDto>> GetPosition(
            [FromRoute] string symbol)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPosition)} was called.");

            var query = new GetPositionQuery()
            {
                Symbol = symbol
            };

            var accessKey = Guid.Parse(User.FindFirstValue("AccessKey"));
            query.Authenticate(accessKey);

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
        [Consumes("application/json")]
        [Produces("application/vnd.trade.hateoas+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.trade.hateoas+json")]
        public async Task<ActionResult<PositionForReturnWithLinksDto>> GetPositionWithLinks(
            [FromRoute] string symbol)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPositionWithLinks)} was called.");

            var query = new GetPositionQuery()
            {
                Symbol = symbol
            };

            var accessKey = Guid.Parse(User.FindFirstValue("AccessKey"));
            query.Authenticate(accessKey);

            var position = await _mediator.Send(query);

            var positionWithLinks = _mapper.Map<PositionForReturnWithLinksDto>(position);

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
        [Consumes("application/json")]
        [Produces("application/vnd.trade.detailedposition.hateoas+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.trade.detailedposition.hateoas+json")]
        public async Task<ActionResult<PositionForReturnWithLinksDto>> GetDetailedPositionWithLinks(
            [FromRoute] string symbol)
        {
            _logger.LogInformation($"PositionsController: {nameof(GetPositionWithLinks)} was called.");

            var query = new GetDetailedPositionQuery()
            {
                Symbol = symbol
            };

            var accessKey = Guid.Parse(User.FindFirstValue("AccessKey"));
            query.Authenticate(accessKey);

            var detailedPosition = await _mediator.Send(query);

            var detailedPositionWithLinks = 
                _mapper.Map<DetailedPositionForReturnWithLinksDto>(detailedPosition);

            detailedPositionWithLinks.SourceTransactionMap =
                detailedPositionWithLinks.SourceTransactionMap
                    .Select(fullSourceLink => 
                    {
                        fullSourceLink.Transaction.Links = 
                            CreateLinksForTransaction(fullSourceLink.Transaction.TransactionId);

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
            GetPositionsQuery query,
            bool hasNext,
            bool hasPrevious)
        {
            var links = new List<LinkDto>();

            links.Add(
                new LinkDto(
                    CreatePositionsResourceUrl(
                        query, 
                        ResourceUriType.CurrentPage),
                    "self",
                    "GET"));

            if (hasNext)
            {
                links.Add(
                    new LinkDto(
                        CreatePositionsResourceUrl(
                            query, 
                            ResourceUriType.NextPage),
                        "nextPage",
                        "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new LinkDto(
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
                            order = query.Order,
                            pageNumber = query.PageNumber - 1,
                            pageSize = query.PageSize,
                            selection = query.Selection,
                            exposure = query.Exposure
                        });

                case ResourceUriType.NextPage:
                    return Url.Link(
                        "GetPositions",
                        new
                        {
                            order = query.Order,
                            pageNumber = query.PageNumber + 1,
                            pageSize = query.PageSize,
                            selection = query.Selection,
                            exposure = query.Exposure
                        });

                case ResourceUriType.CurrentPage:
                default:
                    return Url.Link(
                        "GetPositions",
                        new
                        {
                            order = query.Order,
                            pageNumber = query.PageNumber,
                            pageSize = query.PageSize,
                            selection = query.Selection,
                            exposure = query.Exposure
                        });
            }
        }

        private IEnumerable<LinkDto> CreateLinksForTransaction(
            Guid transactionId)
        {
            var links = new List<LinkDto>();

            links.Add(
                new LinkDto(
                    Url.Link(
                        "GetTransaction", 
                        new { transactionId }),
                "self",
                "GET"));

            links.Add(
                new LinkDto(
                    Url.Link(
                        "UpdateTransaction",
                        new { transactionId }),
                    "update transaction",
                    "PUT"));
                
            links.Add(
                new LinkDto(
                    Url.Link(
                        "PatchTransaction",
                        new { transactionId }),
                    "patch transaction",
                    "PATCH"));

            links.Add(
                new LinkDto(
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