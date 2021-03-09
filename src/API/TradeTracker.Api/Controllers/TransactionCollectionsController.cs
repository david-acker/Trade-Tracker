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
using TradeTracker.Api.ActionConstraints;
using TradeTracker.Api.Helpers;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection;
using TradeTracker.Application.Models.Navigation;

namespace TradeTracker.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPost(Name = "CreateTransactionCollection")]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [Consumes("application/json")]
        [Produces("application/json",
            "application/vnd.trade.hateoas+json")]
        public async Task<ActionResult<IEnumerable<TransactionForReturnDto>>> CreateTransactionCollection(
            [FromBody] IEnumerable<TransactionForCreationDto> commandDtos,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(CreateTransactionCollection)} was called.");

            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }

            var command = new CreateTransactionCollectionCommand()
            {
                Transactions = _mapper.Map<IEnumerable<TransactionForCreationCommandBase>>(commandDtos)
            };
            
            var accessKey = Guid.Parse(User.FindFirstValue("AccessKey"));
            foreach (var transaction in command.Transactions)
            {
                transaction.AccessKey = accessKey;
            }

            var transactionCollection = await _mediator.Send(command);

            var idsAsString = String.Join(",", transactionCollection.Select(t => t.TransactionId));
            
            var transactionCollectionToReturn = transactionCollection.ShapeData(null);
            
            var includeLinks = parsedMediaType.SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
                
            if (includeLinks)
            {
                var linkedTransactionCollection = transactionCollectionToReturn
                    .Select(transaction =>
                    {
                       var transactionAsDictionary = transaction as IDictionary<string, object>;

                       var transactionLinks = CreateLinksForTransaction(
                           (Guid)transactionAsDictionary["TransactionId"], null);
                    
                       transactionAsDictionary.Add("links", transactionLinks);
                       return transactionAsDictionary;
                    });;
                
                return CreatedAtAction(
                    "GetTransactionCollection",
                    new { transactionIds = idsAsString },
                    linkedTransactionCollection);
            }
            else
            {
                return CreatedAtAction(
                    "GetTransactionCollection",
                    new { transactionIds = idsAsString },
                    transactionCollectionToReturn);
            }
        }

        [HttpOptions(Name = "OptionsForTransactionCollections")]
        public IActionResult OptionsForTransactionCollections()
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(OptionsForTransactionCollections)} was called.");

            Response.Headers.Add("Allow", "OPTIONS,POST");
            
            return NoContent();
        }

        [HttpGet("{transactionIds}", Name = "GetTransactionCollection")]
        [Produces("application/json",
            "application/vnd.trade.hateoas+json")]
        public async Task<ActionResult<IEnumerable<TransactionForReturnDto>>> GetTransactionCollection(
            [FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> transactionIds,
            string fields,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(GetTransactionCollection)} was called.");

            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }

            var query = new GetTransactionCollectionQuery()
            {
                AccessKey = Guid.Parse(User.FindFirstValue("AccessKey")),
                TransactionIds = transactionIds
            };

            var returnedTransactions = await _mediator.Send(query);

            var shapedTransactions = returnedTransactions.ShapeData(fields);

            var includeLinks = parsedMediaType.SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);

            if (includeLinks)
            {
                var shapedTransactionsWithLinks = shapedTransactions
                    .Select(transaction =>
                    {
                       var transactionAsDictionary = transaction as IDictionary<string, object>;

                       var transactionLinks = CreateLinksForTransaction(
                           (Guid)transactionAsDictionary["TransactionId"], null);
                    
                       transactionAsDictionary.Add("links", transactionLinks);
                       return transactionAsDictionary;
                    });

                var metadata = new
                {
                    resultsReturnedCount = returnedTransactions.Count()
                };

                var linkedTransactionsResource = new 
                {
                    metadata,
                    results = shapedTransactionsWithLinks
                };

                return Ok(linkedTransactionsResource);
            }
            else
            {
                return Ok(shapedTransactions);
            }
        }

        [HttpOptions("{transactionIds}", Name = "OptionsForTransactionCollectionByTransactionIds")]
        public IActionResult OptionsForTransactionCollectionByTransactionIds()
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(OptionsForTransactionCollectionByTransactionIds)} was called.");

            Response.Headers.Add("Allow", "GET,OPTIONS");
            
            return NoContent();
        }

        private IEnumerable<LinkDto> CreateLinksForTransaction(
            Guid transactionId, 
            string fields)
        {
            var links = new List<LinkDto>();

            if (String.IsNullOrWhiteSpace(fields))
            {
                links.Add(
                    new LinkDto(
                        Url.Link(
                            "GetTransaction", 
                            new { transactionId }),
                    "self",
                    "GET"));
            }
            else
            {
                links.Add(
                    new LinkDto(
                        Url.Link(
                            "GetTransaction", 
                            new { transactionId, fields }),
                    "self",
                    "GET"));
            }

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
}