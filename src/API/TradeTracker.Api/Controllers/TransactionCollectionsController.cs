using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Api.ActionConstraints;
using TradeTracker.Api.Helpers;
using TradeTracker.Api.Utilities;
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
        /// <param name="mediaType">The request media type specified in the Accept header.</param>
        /// <example>
        /// <code>
        /// POST /api/transactioncollections 
        ///
        /// [ 
        ///     { 
        ///         "dateTime": "2019-06-01T12:00:00", 
        ///         "symbol": "XYZ" 
        ///         "type": "SellToOpen", 
        ///         "quantity": "1", 
        ///         "notional": "50", 
        ///         "tradePrice": "50" 
        ///     }, 
        ///     { 
        ///         "dateTime": "2019-06-15T12:00:00", 
        ///         "symbol": "XYZ" 
        ///         "type": "BuyToClose", 
        ///         "quantity": "1", 
        ///         "notional": "40", 
        ///         "tradePrice": "40" 
        ///     }, 
        /// ] 
        /// </code>
        /// </example>
        /// <response code="422">Validation Error</response>
        [HttpPost(Name = "CreateTransactionCollection")]
        [Consumes("application/json")]
        [Produces("application/json",
            "application/vnd.trade.transactioncollection+json",
            "application/vnd.trade.transactioncollection.hateoas+json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/json",
            "application/vnd.trade.transactioncollection+json",
            "application/vnd.trade.transactioncollection.hateoas+json")]
        public async Task<IActionResult> CreateTransactionCollection(
            [FromBody] CreateTransactionCollectionCommand command,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(CreateTransactionCollection)} was called.");

            var transactionCollectionCreated = await _mediator.Send(command);

            bool includeLinks = MediaTypeHeaderValue
                .Parse(mediaType)
                .SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);

            if (includeLinks)
            {
                var transactionCollectionCreatedWithLinks = 
                    new TransactionCollectionCreatedWithLinks();

                transactionCollectionCreatedWithLinks.Items = _mapper
                    .Map<IEnumerable<TransactionForReturnWithLinks>>(
                        transactionCollectionCreated);

                transactionCollectionCreatedWithLinks.Items = 
                    transactionCollectionCreatedWithLinks.Items
                        .Select(transaction => 
                        {
                            transaction.Links = CreateLinksForTransaction(
                                transaction.Id);

                            return transaction;
                        });

                IEnumerable<Guid> transactionIds = 
                    transactionCollectionCreatedWithLinks.Items
                        .Select(t => t.Id);
                
                transactionCollectionCreatedWithLinks.Links = 
                    CreateLinksForTransactionCollection(transactionIds);

                var idsAsString = String.Join(",", transactionIds);
                
                return CreatedAtAction(
                    "GetTransactionCollection",
                    new { transactionIds = idsAsString },
                    transactionCollectionCreatedWithLinks);
            }
            else
            {
                var idsAsString = String.Join(
                    ",", transactionCollectionCreated.Select(t => t.Id));
                
                return CreatedAtAction(
                    "GetTransactionCollection",
                    new { transactionIds = idsAsString },
                    transactionCollectionCreated);
            }
        }


        /// <summary>
        /// Options for /api/transactioncollections URI.
        /// </summary>
        /// <example>
        /// <code>
        /// OPTIONS /api/transactioncollections 
        /// </code>
        /// </example>
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
        /// <param name="ids">The ids for the transactions</param>
        /// <param name="mediaType">The request media type specified in the Accept header.</param>
        /// <example>
        /// <code>
        /// GET /api/transactioncollections/{firstId},{secondId} 
        /// </code>
        /// </example>
        /// <response code="200">Returns the requested transactions</response>
        [EntityTagFilter]
        [HttpGet("{ids}", Name = "GetTransactionCollection")]
        [Produces("application/json", 
            "application/vnd.trade.transactioncollection+json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [RequestHeaderMatchesMediaType("Accept", 
            "application/json",
            "application/vnd.trade.transactioncollection+json")]
        public async Task<IActionResult> GetTransactionCollection(
            [FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(GetTransactionCollection)} was called.");

            var transactionCollection = await _mediator.Send(
                new GetTransactionCollectionQuery() { Ids = ids });

            bool includeLinks = MediaTypeHeaderValue
                .Parse(mediaType)
                .SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);

            if (includeLinks)
            {
                var transactionCollectionWithLinks = 
                    new TransactionCollectionWithLinks();

                transactionCollectionWithLinks.Items = _mapper
                    .Map<IEnumerable<TransactionForReturnWithLinks>>(transactionCollection);

                transactionCollectionWithLinks.Items = transactionCollectionWithLinks.Items
                    .Select(transaction => 
                    {
                        transaction.Links = CreateLinksForTransaction(
                            transaction.Id);
                        
                        return transaction;
                    });
                
                transactionCollectionWithLinks.Links =
                    CreateLinksForTransactionCollection(ids);

                return Ok(transactionCollectionWithLinks);
            }
            else
            {
                return Ok(transactionCollection);
            }
        }


        /// <summary>
        /// Options for /api/transactioncollections/{transactionIds} URI.
        /// </summary>
        /// <example>
        /// <code>
        /// OPTIONS /api/transactioncollections/{firstId},{secondId} 
        /// </code>
        /// </example>
        [HttpOptions("{ids}", Name = "OptionsForTransactionCollectionByIds")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForTransactionCollectionByIds()
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(OptionsForTransactionCollectionByIds)} was called.");

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


        private IEnumerable<Link> CreateLinksForTransactionCollection(
            IEnumerable<Guid> ids)
        {
            var links = new List<Link>();

            links.Add(
                new Link(
                    Url.Link(
                        "GetTransactionCollection",
                        new { ids }),
                    "self",
                    "GET"));
            
            return links;
        }
    }

    #pragma warning restore CS1591
}