using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TradeTracker.Api.Services;
using TradeTracker.Api.DTOs.Transaction;
using TradeTracker.Business.Services;
using TradeTracker.Core.DomainModels.Transaction;
using TradeTracker.Business.AuxiliaryModels;
using TradeTracker.Api.Enums;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Transactions;

namespace TradeTracker.Api.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ILogger<TransactionsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediaTypeService _mediaTypeService;
        private readonly ITransactionsService _transactionsService;

        private string _mediaType => HttpContext?.Request.Headers["Accept"] ?? string.Empty;

        public TransactionsController(
            ICurrentUserService currentUserService,
            ILogger<TransactionsController> logger,
            IMapper mapper,
            IMediaTypeService mediaTypeService,
            ITransactionsService transactionsService)
        {
            _currentUserService = currentUserService;
            _logger = logger;
            _mapper = mapper;
            _mediaTypeService = mediaTypeService;
            _transactionsService = transactionsService;
        }

        [HttpGet]
        [Route("{transactionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes("application/json")]
        [Produces("application/vnd.trade.transaction+json", 
            "application/vnd.trade.transaction.hateoas+json")]
        public async Task<IActionResult> GetAsync(int transactionId)
        {
            _logger.LogInformation($"{nameof(TransactionsController)}: {nameof(GetAsync)} was called for {transactionId}.");

            var transactionDomainModel = await _transactionsService.GetTransaction(transactionId, _currentUserService.AccessKey);
            if (transactionDomainModel == null)
            {
                return NotFound(transactionId);
            }

            var transactionDto = _mapper.Map<TransactionDto>(transactionDomainModel);

            if (_mediaTypeService.IsLinkedRepresentation(_mediaType))
            {
                var linkedTransactionDto = new LinkedTransactionDto
                {
                    Transaction = transactionDto,
                    Links = CreateLinksForTransaction(transactionId)
                };

                return Ok(linkedTransactionDto);
            }
            else
            {
                return Ok(transactionDto);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [Consumes("application/json")]
        [Produces("application/vnd.trade.transaction.paged+json",
            "application/vnd.trade.transaction.paged.hateoas+json")]
        public async Task<IActionResult> GetFilteredAsync(TransactionFilterDto filterModel)
{
            _logger.LogInformation($"{nameof(TransactionsController)}: {nameof(GetFilteredAsync)} was called with filter model: {JsonSerializer.Serialize(filterModel)}.");

            var filterDomainModel = _mapper.Map<TransactionFilterDomainModel>(filterModel);

            var modelState = _transactionsService.ValidateTransactionFilterModel(filterDomainModel);
            if (!modelState.IsValid)
            {
                return UnprocessableEntity(modelState);
            }

            var pagedTransactionsDomainModel = await _transactionsService.GetFilteredTransactions(
                filterDomainModel, 
                _currentUserService.AccessKey);

            var pagedTransactionsDto = _mapper.Map<PaginatedResult<TransactionDto>>(pagedTransactionsDomainModel);

            SetPaginationHeaders(pagedTransactionsDomainModel.Metadata);

            if (_mediaTypeService.IsLinkedRepresentation(_mediaType))
            {
                var linkedTransactionsDto = pagedTransactionsDto.Results
                    .Select(transaction => new LinkedTransactionDto
                    {
                        Transaction = transaction,
                        Links = CreateLinksForTransaction(transaction.TransactionId)
                    });

                var linkedPagedTransactionsDto = new LinkedPaginatedResult<LinkedTransactionDto>(linkedTransactionsDto, pagedTransactionsDto.Metadata);

                linkedPagedTransactionsDto.Links = 
                    CreateLinksForFilteredTransactions(linkedPagedTransactionsDto, filterModel);

                return Ok(linkedPagedTransactionsDto);
            }
            else
            {
                return Ok(pagedTransactionsDto);
            }
        }

        private void SetPaginationHeaders(PaginationMetadata metadata)
        {
            Response.Headers.Add("X-Paging-PageNumber", metadata.Page.ToString());
            Response.Headers.Add("X-Paging-PageSize", metadata.PageSize.ToString());
            Response.Headers.Add("X-Paging-PageCount", metadata.TotalPages.ToString());
            Response.Headers.Add("X-Paging-TotalRecordCount", metadata.TotalRecordCount.ToString());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [Consumes("application/json")]
        [Produces("application/vnd.trade.transaction+json",
            "application/vnd.trade.transaction.hateoas+json")]
        public async Task<IActionResult> CreateAsync(TransactionInputDto inputModel)
        {
            _logger.LogInformation($"{nameof(TransactionsController)}: {nameof(CreateAsync)} was called.");

            var transactionDomainModel = _mapper.Map<TransactionDomainModel>(inputModel);
            
            var modelState = _transactionsService.ValidateTransaction(transactionDomainModel);
            if (!modelState.IsValid)
            {
                return UnprocessableEntity(modelState);
            }

            transactionDomainModel.AccessKey = _currentUserService.AccessKey;

            transactionDomainModel = await _transactionsService.CreateTransaction(transactionDomainModel);
            
            var transactionDto = _mapper.Map<TransactionDto>(transactionDomainModel);

            if (_mediaTypeService.IsLinkedRepresentation(_mediaType))
            {
                var linkedTransactionDto = new LinkedTransactionDto
                {
                    Transaction = transactionDto,
                    Links = CreateLinksForTransaction(transactionDto.TransactionId)
                };

                return CreatedAtAction(
                    nameof(GetAsync),
                    new { transactionId = transactionDto.TransactionId },
                    transactionDto);
            }
            else
            {
                return CreatedAtAction(
                    nameof(GetAsync),
                    new { transactionId = transactionDto.TransactionId },
                    transactionDto);
            }
        }

        [HttpPut]
        [Route("{transactionId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateAsync(int transactionId, TransactionInputDto inputModel)
        {
            _logger.LogInformation($"{nameof(TransactionsController)}: {nameof(UpdateAsync)} was called for {transactionId}.");

            var accessKey = _currentUserService.AccessKey;

            var transaction = await _transactionsService.GetTransaction(transactionId, accessKey);
            if (transaction == null)
            {
                return NotFound(transactionId);
            }

            var transactionDomainModel = _mapper.Map<TransactionDomainModel>(inputModel);
            
            var modelState = _transactionsService.ValidateTransaction(transactionDomainModel);
            if (!modelState.IsValid)
            {
                return UnprocessableEntity(modelState);
            }

            transactionDomainModel.AccessKey = accessKey;

            _mapper.Map(transactionDomainModel, transaction, typeof(TransactionDomainModel), typeof(TransactionDomainModel));

            await _transactionsService.UpdateTransaction(transaction);

            return NoContent();
        }

        [HttpDelete]
        [Route("{transactionId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int transactionId)
        {
            _logger.LogInformation($"{nameof(TransactionsController)}: {nameof(DeleteAsync)} was called for {transactionId}.");

            var accessKey = _currentUserService.AccessKey;

            var transaction = await _transactionsService.GetTransaction(transactionId, accessKey);
            if (transaction == null)
            {
                return NotFound(transactionId);
            }

            await _transactionsService.DeleteTransaction(transaction);

            return NoContent();
        }

        [HttpOptions]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Options()
{
            _logger.LogInformation($"{nameof(TransactionsController)}: {nameof(Options)} was called.");

            Response.Headers.Add("Allow", "GET,OPTIONS,POST");

            return NoContent();
        }

        [HttpOptions]
        [Route("{transactionId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForTransactionId()
        {
            _logger.LogInformation($"{nameof(TransactionsController)}: {nameof(OptionsForTransactionId)} was called.");

            Response.Headers.Add("Allow", "DELETE,GET,OPTIONS,PUT");

            return NoContent();
        }

        private IEnumerable<Link> CreateLinksForTransaction(int transactionId)
        {
            var links = new List<Link>
            {
                new Link
                {
                    Href = Url.Link(nameof(GetAsync), new { transactionId = transactionId }),
                    Rel = "self",
                    Method = HttpMethod.Get.ToString()
                }, 
                new Link
                {
                    Href = Url.Link(nameof(UpdateAsync), new { transactionId = transactionId }),
                    Rel = "self",
                    Method = HttpMethod.Put.ToString()
                },
                new Link
                {
                    Href = Url.Link(nameof(DeleteAsync), new { transactionId = transactionId }),
                    Rel = "self",
                    Method = HttpMethod.Delete.ToString()
                }
            };

            return links;
        }

        private IEnumerable<Link> CreateLinksForFilteredTransactions(
            LinkedPaginatedResult<LinkedTransactionDto> paginatedResult,
            TransactionFilterDto filterModel)
        {
            var links = new List<Link>
            {
                new Link
                {
                    Href = CreateFilteredTransactionsResourceUrl(
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
                        Href = CreateFilteredTransactionsResourceUrl(
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
                        Href = CreateFilteredTransactionsResourceUrl(
                            ResourceUriType.CurrentPage,
                            filterModel),
                        Rel = "nextPage",
                        Method = HttpMethod.Get.ToString()
                    });
            }

            return links;
        }

        private string CreateFilteredTransactionsResourceUrl(
            ResourceUriType uriType,
            TransactionFilterDto filterModel)
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
                    StartDate = filterModel.StartDate,
                    EndDate = filterModel.EndDate,
                    Symbol = filterModel.Symbol,
                    TransactionType = filterModel.TransactionType,
                    OrderByField = filterModel.OrderByField,
                    OrderByDirection = filterModel.OrderByDirection
                });
        }
    }
}
