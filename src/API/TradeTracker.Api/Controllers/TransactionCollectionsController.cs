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
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Api.Controllers
{
    #pragma warning disable CS1591

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class TransactionCollectionsController : Controller
    {
        private readonly ILogger<TransactionCollectionsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TransactionCollectionsController(
            IMapper mapper, 
            IMediator mediator,
            ILogger<TransactionCollectionsController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }


        /// <summary>
        /// Create a collection of transactions.
        /// </summary>
        /// <param name="command">The transactions to be created</param>
        /// <remarks>
        /// Example: \
        /// POST /api/transactioncollections \
        /// [ \
        ///     { \
        ///         "dateTime": "2019-06-01T12:00:00", \
        ///         "symbol": "XYZ" \
        ///         "type": "SellToOpen", \
        ///         "quantity": "1", \
        ///         "notional": "50", \
        ///         "tradePrice": "50" \
        ///     }, \
        ///     { \
        ///         "dateTime": "2019-06-15T12:00:00", \
        ///         "symbol": "XYZ" \
        ///         "type": "BuyToClose", \
        ///         "quantity": "1", \
        ///         "notional": "40", \
        ///         "tradePrice": "40" \
        ///     }, \
        /// ] 
        /// </remarks>
        /// <response code="422">Validation Error</response>
        [HttpPost(Name = "CreateTransactionCollection")]
        [Consumes("application/json")]
        [Produces("application/json",
            "application/vnd.trade.transactioncollection+json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/json",
            "application/vnd.trade.transactioncollection+json")]
        public async Task<ActionResult<IEnumerable<TransactionForReturnDto>>> CreateTransactionCollection(
            [FromBody] CreateTransactionCollectionCommand command)
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(CreateTransactionCollection)} was called.");

            var transactionCollectionCreated = await _mediator.Send(command);

            var idsAsString = String.Join(
                ",", transactionCollectionCreated.Select(t => t.TransactionId));
                
            return CreatedAtAction(
                "GetTransactionCollection",
                new { transactionIds = idsAsString },
                transactionCollectionCreated);
        }


        /// <summary>
        /// Create a collection of transactions.
        /// </summary>
        /// <param name="command">The transactions to be created</param>
        /// <remarks>
        /// Example: \
        /// POST /api/transactioncollections \
        /// [ \
        ///     { \
        ///         "dateTime": "2019-06-01T12:00:00", \
        ///         "symbol": "XYZ" \
        ///         "type": "SellToOpen", \
        ///         "quantity": "1", \
        ///         "notional": "50", \
        ///         "tradePrice": "50" \
        ///     }, \
        ///     { \
        ///         "dateTime": "2019-06-15T12:00:00", \
        ///         "symbol": "XYZ" \
        ///         "type": "BuyToClose", \
        ///         "quantity": "1", \
        ///         "notional": "40", \
        ///         "tradePrice": "40" \
        ///     }, \
        /// ] 
        /// </remarks>
        /// <response code="422">Validation Error</response>
        [HttpPost(Name = "CreateTransactionCollectionWithLinks")]
        [Consumes("application/json")]
        [Produces("application/vnd.trade.transactioncollection.hateoas+json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/vnd.trade.transactioncollection.hateoas+json")]
        public async Task<ActionResult<TransactionCollectionCreatedWithLinksDto>> CreateTransactionCollectionWithLinks(
            [FromBody] CreateTransactionCollectionCommand command)
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(CreateTransactionCollectionWithLinks)} was called.");

            var transactionCollectionCreated = await _mediator.Send(command);

            var transactionCollectionCreatedWithLinks = 
                new TransactionCollectionCreatedWithLinksDto();

            transactionCollectionCreatedWithLinks.Items = _mapper
                .Map<IEnumerable<TransactionForReturnWithLinksDto>>(
                    transactionCollectionCreated);

            transactionCollectionCreatedWithLinks.Items = 
                transactionCollectionCreatedWithLinks.Items
                    .Select(transaction => 
                    {
                        transaction.Links = CreateLinksForTransaction(
                            transaction.TransactionId);

                        return transaction;
                    });

            IEnumerable<Guid> transactionIds = 
                transactionCollectionCreatedWithLinks.Items
                    .Select(t => t.TransactionId);
            
            transactionCollectionCreatedWithLinks.Links = 
                CreateLinksForTransactionCollection(transactionIds);

            var idsAsString = String.Join(",", transactionIds);
            
            return CreatedAtAction(
                "GetTransactionCollection",
                new { transactionIds = idsAsString },
                transactionCollectionCreatedWithLinks);
        }


        /// <summary>
        /// Options for /api/transactioncollections URI.
        /// </summary>
        /// <remarks>
        /// Example: \
        /// OPTIONS /api/transactioncollections 
        /// </remarks>
        [HttpOptions(Name = "OptionsForTransactionCollections")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForTransactionCollections()
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(OptionsForTransactionCollections)} was called.");

            Response.Headers.Add("Allow", "OPTIONS,POST");
            
            return NoContent();
        }


        /// <summary>
        /// Get a collection of transactions.
        /// </summary>
        /// <param name="transactionIds">The ids for the transactions</param>
        /// <remarks>
        /// Example: \
        /// GET /api/transactioncollections/{firstTransactionId},{secondTransactionId} 
        /// </remarks>
        /// <response code="200">Returns the requested transactions</response>
        [HttpGet("{transactionIds}", Name = "GetTransactionCollection")]
        [Produces("application/json", 
            "application/vnd.trade.transactioncollection+json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/json",
            "application/vnd.trade.transactioncollection+json")]
        public async Task<ActionResult<IEnumerable<TransactionForReturnDto>>> GetTransactionCollection(
            [FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> transactionIds)
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(GetTransactionCollection)} was called.");

            var query = new GetTransactionCollectionQuery() { TransactionIds = transactionIds };

            var transactionCollection = await _mediator.Send(query);

            return Ok(transactionCollection);
        }


        /// <summary>
        /// Get a collection of transactions.
        /// </summary>
        /// <param name="transactionIds">The ids for the transactions</param>
        /// <remarks>
        /// Example: \
        /// GET /api/transactioncollections/{firstTransactionId},{secondTransactionId} 
        /// </remarks>
        /// <response code="200">Returns the requested transactions</response>
        [HttpGet("{transactionIds}", Name = "GetTransactionCollectionWithLinks")]
        [Produces("application/vnd.trade.transactioncollection.hateoas+json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/vnd.trade.transactioncollection.hateoas+json")]
        public async Task<ActionResult<TransactionCollectionWithLinksDto>> GetTransactionCollectionWithLinks(
            [FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> transactionIds)
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(GetTransactionCollectionWithLinks)} was called.");

            var query = new GetTransactionCollectionQuery() { TransactionIds = transactionIds };

            var transactionCollection = await _mediator.Send(query);

            var transactionCollectionWithLinks = new TransactionCollectionWithLinksDto();

            transactionCollectionWithLinks.Items = _mapper
                .Map<IEnumerable<TransactionForReturnWithLinksDto>>(transactionCollection);

            transactionCollectionWithLinks.Items = transactionCollectionWithLinks.Items
                .Select(transaction => 
                {
                    transaction.Links = CreateLinksForTransaction(
                        transaction.TransactionId);
                    
                    return transaction;
                });
            
            transactionCollectionWithLinks.Links =
                CreateLinksForTransactionCollection(transactionIds);

            return Ok(transactionCollectionWithLinks);
        }


        /// <summary>
        /// Options for /api/transactioncollections/{transactionIds} URI.
        /// </summary>
        /// <remarks>
        /// Example: \
        /// OPTIONS /api/transactioncollections/{firstTransactionId},{secondTransactionId} 
        /// </remarks>
        [HttpOptions("{transactionIds}", Name = "OptionsForTransactionCollectionByTransactionIds")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForTransactionCollectionByTransactionIds()
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(OptionsForTransactionCollectionByTransactionIds)} was called.");

            Response.Headers.Add("Allow", "GET,OPTIONS");
            
            return NoContent();
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


        private IEnumerable<LinkDto> CreateLinksForTransactionCollection(
            IEnumerable<Guid> transactionIds)
        {
            var links = new List<LinkDto>();

            links.Add(
                new LinkDto(
                    Url.Link(
                        "GetTransactionCollection",
                        new { transactionIds }),
                    "self",
                    "GET"));
            
            return links;
        }
    }

    #pragma warning restore CS1591
}