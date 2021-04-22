using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Api.ActionConstraints;
using TradeTracker.Api.Extensions;
using TradeTracker.Api.Helpers;
using TradeTracker.Api.Utilities;
using TradeTracker.Application.Features.Transactions.Commands;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction;
using TradeTracker.Application.Features.Transactions.Commands.PatchTransaction;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Features.Transactions.Queries.ExportTransactions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransaction;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Api.Controllers
{
    #pragma warning disable CS1591

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class TransactionsController : Controller
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TransactionsController(
            IMapper mapper, 
            IMediator mediator,
            ILogger<TransactionsController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }


        /// <summary>
        /// Get a paged list of transactions.
        /// </summary>
        /// <param name="query">The resource parameters for specifying the returned transactions</param>
        /// <param name="mediaType">The request media type specified in the Accept header.</param>
        /// <remarks>
        /// Example:
        ///
        ///     GET /api/transactions
        ///     { 
        ///         "orderBy": "DateTime", 
        ///         "pageNumber": "2" 
        ///         "pageSize": "50", 
        ///         "including": [ 
        ///             "ABC", 
        ///             "XYZ", 
        ///             "MNO" 
        ///         ], 
        ///         "rangeStart": "2020-06-01T00:00:00", 
        ///         "rangeEnd": "2021-01-01T00:00:00" 
        ///     } 
        /// 
        /// </remarks>
        /// <response code="200">Returns any paged transactions matching parameters</response>
        /// <response code="422">Validation Error</response>
        [HttpGet(Name = "GetPagedTransactions")]
        [Consumes("application/json")]
        [Produces("application/json",
            "application/vnd.trade.pagedtransactions+json",
            "application/vnd.trade.pagedtransactions.hateoas+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/json",
            "application/vnd.trade.pagedtransactions+json",
            "application/vnd.trade.pagedtransactions.hateoas+json")]
        public async Task<IActionResult> GetPagedTransactions(
            [FromQuery] GetTransactionsQuery query,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"TransactionsController: {nameof(GetPagedTransactions)} was called.");

            var pagedTransactionsBase = await _mediator.Send(query);

            var parsedMediaType = MediaTypeHeaderValue.Parse(mediaType);
            bool includeLinks = parsedMediaType.IsRepresentationWithLinks();
            
            if (includeLinks)
            {
                var pagedTransactionsWithLinks = new PagedTransactionsWithLinks()
                {
                    Items = _mapper
                        .Map<IEnumerable<TransactionForReturnWithLinks>>(pagedTransactionsBase.Items)
                        .Select(transaction => 
                        {
                            transaction.Links = CreateLinksForTransaction(transaction.Id);
                            return transaction;
                        })
                };
                
                pagedTransactionsWithLinks.Links = 
                    CreateLinksForTransactions(
                        query,
                        pagedTransactionsBase.HasNext,
                        pagedTransactionsBase.HasPrevious);

                return Ok(pagedTransactionsWithLinks);
            }
            else
            {
                Response.Headers.Add("X-Paging-PageNumber",
                    pagedTransactionsBase.Metadata.PageNumber.ToString());
                Response.Headers.Add("X-Paging-PageSize",
                    pagedTransactionsBase.Metadata.PageSize.ToString());
                Response.Headers.Add("X-Paging-PageCount",
                    pagedTransactionsBase.Metadata.PageCount.ToString());
                Response.Headers.Add("X-Paging-TotalRecordCount",
                    pagedTransactionsBase.Metadata.TotalRecordCount.ToString());

                return Ok(pagedTransactionsBase.Items);
            } 
        }

        /// <summary>
        /// Create a transaction.
        /// </summary>
        /// <param name="command">The transaction to be created</param>
        /// <param name="mediaType">The request media type specified in the Accept header.</param>
        /// <remarks>
        /// Example:
        ///
        ///     POST /api/transactions 
        ///     { 
        ///         "dateTime": "2020-01-01T12:30:15", 
        ///         "symbol": "ABC" 
        ///         "type": "BuyToOpen", 
        ///         "quantity": "2.5", 
        ///         "notional": "13.75", 
        ///         "tradePrice": "5.50" 
        ///     }
        ///
        /// </remarks>
        /// <response code="422">Validation Error</response>
        [HttpPost(Name = "CreateTransaction")]
        [Consumes("application/json")]
        [Produces("application/json",
            "application/vnd.trade.transaction+json",
            "application/vnd.trade.transaction.hateoas+json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/json",
            "application/vnd.trade.transaction+json",
            "application/vnd.trade.transaction.hateoas+json")]
        public async Task<IActionResult> CreateTransaction(
            [FromBody] CreateTransactionCommand command,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"TransactionsController: {nameof(CreateTransaction)} was called.");

            var transactionCreated = await _mediator.Send(command);

            var parsedMediaType = MediaTypeHeaderValue.Parse(mediaType);
            bool includeLinks = parsedMediaType.IsRepresentationWithLinks();

            if (includeLinks)
            {
                var transactionCreatedWithLinks =
                    _mapper.Map<TransactionForReturnWithLinks>(transactionCreated); 

                transactionCreatedWithLinks.Links = CreateLinksForTransaction(
                    transactionCreatedWithLinks.Id);

                return CreatedAtAction(
                    "GetTransaction",
                    new { transactionId = transactionCreatedWithLinks.Id },
                    transactionCreatedWithLinks);
            }
            else
            {
                return CreatedAtAction(
                    "GetTransaction",
                    new { transactionId = transactionCreated.Id },
                    transactionCreated);
            }
        }

        /// <summary>
        /// Options for /api/transactions URI.
        /// </summary>
        /// <remarks>
        /// Example:
        ///
        ///     OPTIONS /api/transactions 
        /// 
        /// </remarks>
        [HttpOptions(Name = "OptionsForTransactions")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForTransactions()
        {
            _logger.LogInformation($"TransactionsController: {nameof(OptionsForTransactions)} was called.");
            
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            
            return NoContent();
        }

        /// <summary>
        /// Get a transaction by its id.
        /// </summary>
        /// <param name="id">The id of the transaction</param>
        /// <param name="mediaType">The request media type specified in the Accept header.</param>
        /// <remarks>
        /// Example:
        /// 
        ///     GET /api/transactions/{id} 
        ///
        /// </remarks>
        /// <response code="200">Returns the requested transaction</response>
        [HttpGet("{id}", Name = "GetTransaction")]
        [EntityTagFilter]
        [Produces("application/json",
            "application/vnd.trade.transaction+json",
            "application/vnd.trade.transaction.hateoas+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/json",
            "application/vnd.trade.transaction+json",
            "application/vnd.trade.transaction.hateoas+json")]
        public async Task<IActionResult> GetTransaction(
            [FromRoute] Guid id,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"TransactionsController: {nameof(GetTransaction)} was called.");

            var transaction = await _mediator.Send(
                new GetTransactionQuery() { Id = id });

            var parsedMediaType = MediaTypeHeaderValue.Parse(mediaType);
            bool includeLinks = parsedMediaType.IsRepresentationWithLinks();

            if (includeLinks)
            {
                var transactionWithLinks = _mapper.Map<TransactionForReturnWithLinks>(transaction);

                transactionWithLinks.Links = CreateLinksForTransaction(id);

                return Ok(transactionWithLinks);
            }
            else
            {
                return Ok(transaction);
            } 
        }


        /// <summary>
        /// Update a transaction.
        /// </summary>
        /// <param name="id">The id for the transaction to be updated</param>
        /// <param name="command">The transaction with updated values</param>
        /// <response code="422">Validation Error</response>
        /// <remarks>
        /// Example:
        ///
        ///     PUT /api/transactions/{id} 
        ///     { 
        ///         "dateTime": "2020-01-15T15:00:00", 
        ///         "symbol": "CBA",
        ///         "type": "SellToClose", 
        ///         "quantity": "1.0", 
        ///         "notional": "12.50", 
        ///         "tradePrice": "12.50" 
        ///     } 
        ///
        /// </remarks>
        [HttpPut("{id}", Name = "UpdateTransaction")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        public async Task<ActionResult> UpdateTransaction(
            [FromRoute] Guid id, 
            [FromBody] UpdateTransactionCommand command)
        {
            _logger.LogInformation($"TransactionsController: {nameof(UpdateTransaction)} was called.");

            command.Id = id;
            
            await _mediator.Send(command);
            return NoContent();
        }


        /// <summary>
        /// Partially update a transaction.
        /// </summary>
        /// <param name="id">The id for the transaction to be updated</param>
        /// <param name="patchDocument">The set of operations to be applied to the transaction</param>
        /// <remarks>
        /// Example:
        ///
        ///     PATCH /api/transactions/{id} 
        ///     [ 
        ///         { 
        ///             "op": "replace", 
        ///             "path": "/quantity", 
        ///             "value": "25" 
        ///         }, 
        ///         { 
        ///             "op": "replace", 
        ///             "path": "/notional",
        ///             "value": "75" 
        ///         } 
        ///     ]
        ///
        /// </remarks>
        /// <response code="422">Validation Error</response>
        [HttpPatch("{id}", Name = "PatchTransaction")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        public async Task<ActionResult> PatchTransaction(
            [FromRoute] Guid id, 
            JsonPatchDocument<UpdateTransactionCommandBase> patchDocument)
        {
            _logger.LogInformation($"TransactionsController: {nameof(PatchTransaction)} was called.");

            var command = new PatchTransactionCommand()
            {
                Id = id,
                PatchDocument = patchDocument
            };

            await _mediator.Send(command);
            return NoContent();
        }


        /// <summary>
        /// Delete a transaction.
        /// </summary>
        /// <param name="id">The id for the transaction to be deleted</param>
        /// <remarks>
        /// Example:
        ///
        ///     DELETE /api/transactions/{id} 
        /// 
        /// </remarks>
        [HttpDelete("{id}", Name = "DeleteTransaction")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTransaction(
            [FromRoute] Guid id)
        {
            _logger.LogInformation($"TransactionsController: {nameof(DeleteTransaction)} was called.");

            var command = new DeleteTransactionCommand() { Id = id };

            await _mediator.Send(command);
            return NoContent();
        }


        /// <summary>
        /// Options for /api/transactions/{id} URI.
        /// </summary>
        /// <remarks>
        /// Example:
        ///
        ///     OPTIONS /api/transactions/{id} 
        ///
        /// </remarks>
        [HttpOptions("{id}", Name = "OptionsForTransactionById")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForTransactionById()
        {
            _logger.LogInformation($"TransactionsController: {nameof(OptionsForTransactionById)} was called.");

            Response.Headers.Add("Allow", "DELETE,GET,OPTIONS,PATCH,PUT");
            
            return NoContent();
        }


        /// <summary>
        /// Get all transactions as a CSV file.
        /// </summary>
        /// <remarks>
        /// Example:
        ///
        ///     GET /api/transactions/export
        /// 
        /// </remarks>
        /// <response code="200"></response>
        [HttpGet("export", Name = "ExportTransactions")]
        [FileResultContentType("text/csv")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExportTransactions()
        {
            _logger.LogInformation($"TransactionsController: {nameof(ExportTransactions)} was called.");

            var query = new ExportTransactionsQuery();

            var fileExportDto = await _mediator.Send(query);
            return File(
                fileExportDto.Data, 
                fileExportDto.ContentType, 
                fileExportDto.TransactionsExportFileName);
        }


        /// <summary>
        /// Options for /api/transactions/export URI.
        /// </summary>
        /// <remarks>
        /// Example:
        ///
        ///     OPTIONS /api/transactions/export 
        /// 
        /// </remarks>
        [HttpOptions("export", Name = "OptionsForExportTransactions")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForExportTransactions()
        {
            _logger.LogInformation($"TransactionsController: {nameof(OptionsForExportTransactions)} was called.");

            Response.Headers.Add("Allow", "GET,OPTIONS");
            
            return NoContent();
        }


        private IEnumerable<Link> CreateLinksForTransaction(
            Guid id)
        {
            var links = new List<Link>();

            links.Add(
                new Link(
                    Url.Link(
                        "GetTransaction", 
                        new { id }),
                "self",
                "GET"));

            links.Add(
                new Link(
                    Url.Link(
                        "UpdateTransaction",
                        new { id }),
                    "update transaction",
                    "PUT"));
                
            links.Add(
                new Link(
                    Url.Link(
                        "PatchTransaction",
                        new { id }),
                    "patch transaction",
                    "PATCH"));

            links.Add(
                new Link(
                    Url.Link(
                        "DeleteTransaction",
                        new { id }),
                    "delete transaction",
                    "DELETE"));

            return links;
        }


        private IEnumerable<Link> CreateLinksForTransactions(
            GetTransactionsQuery query,
            bool hasNext,
            bool hasPrevious)
        {
            var links = new List<Link>();

            links.Add(
                new Link(
                    CreateTransactionsResourceUrl(
                        query, 
                        ResourceUriType.CurrentPage),
                    "self",
                    "GET"));

            if (hasNext)
            {
                links.Add(
                    new Link(
                        CreateTransactionsResourceUrl(
                            query, 
                            ResourceUriType.NextPage),
                        "nextPage",
                        "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new Link(
                        CreateTransactionsResourceUrl(
                            query, 
                            ResourceUriType.PreviousPage),
                        "previousPage",
                        "GET"));
            }

            return links;
        }


        private string CreateTransactionsResourceUrl(
            GetTransactionsQuery query,
            ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link(
                        "GetTransactions",
                        new
                        {
                            orderBy = query.OrderBy,
                            transactionType = query.TransactionType,
                            pageNumber = query.PageNumber - 1,
                            pageSize = query.PageSize,
                            symbolSelection = query.SymbolSelection,
                            rangeStart = query.RangeStart,
                            rangeEnd = query.RangeEnd
                        });

                case ResourceUriType.NextPage:
                    return Url.Link(
                        "GetTransactions",
                        new
                        {
                            orderBy = query.OrderBy,
                            transactionType = query.TransactionType,
                            pageNumber = query.PageNumber + 1,
                            pageSize = query.PageSize,
                            symbolSelection = query.SymbolSelection,
                            rangeStart = query.RangeStart,
                            rangeEnd = query.RangeEnd
                        });

                case ResourceUriType.CurrentPage:
                default:
                    return Url.Link(
                        "GetTransactions",
                        new
                        {
                            orderBy = query.OrderBy,
                            transactionType = query.TransactionType,
                            pageNumber = query.PageNumber,
                            pageSize = query.PageSize,
                            symbolSelection = query.SymbolSelection,
                            rangeStart = query.RangeStart,
                            rangeEnd = query.RangeEnd
                        });
            }
        }        
    }

    #pragma warning restore CS1591
}
