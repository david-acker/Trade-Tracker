using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TradeTracker.Api.DTOs.Position;
using TradeTracker.Api.Enums;
using TradeTracker.Api.Services;
using TradeTracker.Business.AuxiliaryModels;
using TradeTracker.Business.Services;
using TradeTracker.Core.DomainModels.Position;

namespace TradeTracker.Api.Controllers
{
    [Route("api/positions")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ILogger<PositionsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediaTypeService _mediaTypeService;
        private readonly IPositionsService _positionsService;

        private string _mediaType => HttpContext?.Request.Headers["Accept"] ?? string.Empty;

        public PositionsController(
            ICurrentUserService currentUserService,
            ILogger<PositionsController> logger,
            IMapper mapper,
            IMediaTypeService mediaTypeService,
            IPositionsService positionsService)
        {
            _currentUserService = currentUserService;
            _logger = logger;
            _mapper = mapper;
            _mediaTypeService = mediaTypeService;
            _positionsService = positionsService;
        }

        [HttpGet]
        [Route("{symbol}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes("application/json")]
        [Produces("application/vnd.trade.position+json",
            "application/vnd.trade.position.hateoas+json")]
        public async Task<IActionResult> GetAsync(string symbol)
        {
            _logger.LogInformation($"{nameof(PositionsController)}: {nameof(GetAsync)} was called for {symbol}.");

            var positionDomainModel = await _positionsService.GetPosition(symbol, _currentUserService.AccessKey);
            if (positionDomainModel == null)
            {
                return NotFound(symbol);
            }

            var positionDto = _mapper.Map<PositionDto>(positionDomainModel);

            if (_mediaTypeService.IsLinkedRepresentation(_mediaType))
            {
                var linkedPositionDto = new LinkedPositionDto
                {
                    Position = positionDto,
                    Links = CreateLinksForPosition(symbol)
                };

                return Ok(linkedPositionDto);
            }
            else
            {
                return Ok(positionDto);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [Consumes("application/json")]
        [Produces("application/vnd.trade.position.paged+json",
            "application/vnd.trade.position.paged.hateoas+json")]
        public async Task<IActionResult> GetFilteredAsync(PositionFilterDto filterModel)
        {
            _logger.LogInformation($"{nameof(PositionsController)}: {nameof(GetFilteredAsync)} was called with filter model: {JsonSerializer.Serialize(filterModel)}.");

            var filterDomainModel = _mapper.Map<PositionFilterDomainModel>(filterModel);

            var modelState = _positionsService.ValidatePositionFilterModel(filterDomainModel);
            if (!modelState.IsValid)
            {
                return UnprocessableEntity(modelState);
            }

            var pagedPositionsDomainModel = await _positionsService.GetFilteredPositions(
                filterDomainModel,
                _currentUserService.AccessKey);

            var pagedPositionsDto = _mapper.Map<PaginatedResult<PositionDto>>(pagedPositionsDomainModel);

            SetPaginationHeaders(pagedPositionsDomainModel.Metadata);

            if (_mediaTypeService.IsLinkedRepresentation(_mediaType))
            {
                var linkedPositionsDto = pagedPositionsDto.Results
                    .Select(position => new LinkedPositionDto
                    {
                        Position = position,
                        Links = CreateLinksForPosition(position.Symbol)
                    });

                var linkedPagedPositionsDto = new LinkedPaginatedResult<LinkedPositionDto>(linkedPositionsDto, pagedPositionsDto.Metadata);

                linkedPagedPositionsDto.Links =
                    CreateLinksForFilteredPositions(linkedPagedPositionsDto, filterModel);

                return Ok(linkedPagedPositionsDto);
            }
            else
            {
                return Ok(pagedPositionsDto);
            }
        }

        [HttpOptions]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Options()
        {
            _logger.LogInformation($"{ nameof(PositionsController)}: {nameof(Options)}");

            Response.Headers.Add("Allow", "GET,OPTIONS");

            return NoContent();
        }

        [HttpOptions]
        [Route("{symbol}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForSymbol()
        {
            _logger.LogInformation($"{ nameof(PositionsController)}: {nameof(OptionsForSymbol)}");

            Response.Headers.Add("Allow", "GET,OPTIONS");

            return NoContent();
        }

        private void SetPaginationHeaders(PaginationMetadata metadata)
        {
            Response.Headers.Add("X-Paging-PageNumber", metadata.Page.ToString());
            Response.Headers.Add("X-Paging-PageSize", metadata.PageSize.ToString());
            Response.Headers.Add("X-Paging-PageCount", metadata.TotalPages.ToString());
            Response.Headers.Add("X-Paging-TotalRecordCount", metadata.TotalRecordCount.ToString());
        }

        private IEnumerable<Link> CreateLinksForPosition(string symbol)
        {
            var links = new List<Link>
            {
                new Link
                {
                    Href = Url.Link(nameof(GetAsync), new { symbol = symbol }),
                    Rel = "self",
                    Method = HttpMethod.Get.ToString()
                }
            };

            return links;
        }

        private IEnumerable<Link> CreateLinksForFilteredPositions(
            LinkedPaginatedResult<LinkedPositionDto> paginatedResult,
            PositionFilterDto filterModel)
        {
            var links = new List<Link>
            {
                new Link
                {
                    Href = CreateFilteredPositionsResourceUrl(
                        ResourceUriType.CurrentPage,
                        filterModel),
                    Rel = "self",
                    Method = HttpMethod.Get.ToString()
                }
            };

            if (paginatedResult.HasPrevious)
            {
                links.Add(
                    new Link
                    {
                        Href = CreateFilteredPositionsResourceUrl(
                            ResourceUriType.CurrentPage,
                            filterModel),
                        Rel = "previousPage",
                        Method = HttpMethod.Get.ToString()
                    });
            }

            if (paginatedResult.HasNext)
            {
                links.Add(
                    new Link
                    {
                        Href = CreateFilteredPositionsResourceUrl(
                            ResourceUriType.CurrentPage,
                            filterModel),
                        Rel = "nextPage",
                        Method = HttpMethod.Get.ToString()
                    });
            }

            return links;
        }

        private string CreateFilteredPositionsResourceUrl(
            ResourceUriType uriType,
            PositionFilterDto filterModel)
        {
            int targetPage;

            switch (uriType)
            {
                case ResourceUriType.PreviousPage:
                    targetPage = filterModel.Page - 1;
                    break;

                case ResourceUriType.NextPage:
                    targetPage = filterModel.Page + 1;
                    break;

                case ResourceUriType.CurrentPage:
                default:
                    targetPage = filterModel.Page;
                    break;
            }

            return Url.Link(
                nameof(GetFilteredAsync),
                new
                {
                    Page = targetPage,
                    PageSize = filterModel.PageSize,
                    PositionType = filterModel.PositionType,
                    OrderByField = filterModel.OrderByField,
                    OrderByDirection = filterModel.OrderByDirection
                });
        }
    }
}
