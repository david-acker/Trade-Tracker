using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using TradeTracker.Api.ActionConstraints;
using TradeTracker.Api.Helpers;
using TradeTracker.Api.Utilities;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction;
using TradeTracker.Application.Features.Transactions.Commands.PatchTransaction;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Features.Transactions.Queries.ExportTransactions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransaction;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Application.Models.Navigation;

namespace TradeTracker.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet(Name = "GetTransactions")]
        [Produces("application/json",
            "application/vnd.trade.hateoas+json")]
        public async Task<ActionResult<PagedTransactionsDto>> GetTransactions(
            [FromQuery] GetTransactionsResourceParameters parameters,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"TransactionsController: {nameof(GetTransactions)} was called.");

            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }

            var query = _mapper.Map<GetTransactionsQuery>(parameters);
            query.AccessKey = Guid.Parse(User.FindFirstValue("AccessKey"));

            var returnedTransactions = await _mediator.Send(query);

            var shapedTransactions = returnedTransactions.Items
                .ShapeData(parameters.Fields);

            var includeLinks = parsedMediaType.SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);

            if (includeLinks)
            {
                var links = CreateLinksForTransactions(
                    parameters,
                    returnedTransactions.HasNext,
                    returnedTransactions.HasPrevious);
                
                var shapedTransactionsWithLinks = shapedTransactions
                    .Select(transaction =>
                    {
                       var transactionAsDictionary = transaction as IDictionary<string, object>;

                       var transactionLinks = CreateLinksForTransaction(
                           (Guid)transactionAsDictionary["TransactionId"], null);
                    
                       transactionAsDictionary.Add("links", transactionLinks);
                       return transactionAsDictionary;
                    });
                
                var paginationMetadata = new
                {
                    pageNumber = returnedTransactions.CurrentPage,
                    pageSize = returnedTransactions.PageSize,
                    pageCount = returnedTransactions.TotalPages,
                    totalRecordCount = returnedTransactions.TotalCount,
                };

                var linkedTransactionsResource = new 
                {
                    paginationMetadata = paginationMetadata,
                    results = shapedTransactionsWithLinks,
                    links
                };

                return Ok(linkedTransactionsResource);
            }
            else
            {
                Response.Headers.Add("X-Paging-PageNumber", returnedTransactions.CurrentPage.ToString());
                Response.Headers.Add("X-Paging-PageSize", returnedTransactions.PageSize.ToString());
                Response.Headers.Add("X-Paging-PageCount", returnedTransactions.TotalPages.ToString());
                Response.Headers.Add("X-Paging-TotalRecordCount", returnedTransactions.TotalCount.ToString());

                return Ok(shapedTransactions);
            }
        }

        [HttpPost(Name = "CreateTransaction")]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [Consumes("application/json")]
        [Produces("application/json",
            "application/vnd.trade.hateoas+json")]
        public async Task<ActionResult<TransactionForReturnDto>> CreateTransaction(
            [FromBody] CreateTransactionCommandDto commandDto,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"TransactionsController: {nameof(CreateTransaction)} was called.");

            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }

            var command = _mapper.Map<CreateTransactionCommand>(commandDto);
            command.AccessKey = Guid.Parse(User.FindFirstValue("AccessKey"));

            var createdTransaction = await _mediator.Send(command);

            var linkedTransaction = createdTransaction
                .ShapeData(null) as IDictionary<string, object>;

            var includeLinks = parsedMediaType.SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
                
            if (includeLinks)
            {
                var links = CreateLinksForTransaction(
                    (Guid)linkedTransaction["TransactionId"], null);
                
                linkedTransaction.Add("links", links);

                return CreatedAtAction(
                    "GetTransaction",
                    new { transactionId = linkedTransaction["TransactionId"] },
                    linkedTransaction);
            }
            else
            {
                return CreatedAtAction(
                    "GetTransaction",
                    new { transactionId = linkedTransaction["TransactionId"] },
                    createdTransaction);
            }
        }

        [HttpOptions(Name = "OptionsForTransactions")]
        public IActionResult OptionsForTransactions()
        {
            _logger.LogInformation($"TransactionsController: {nameof(OptionsForTransactions)} was called.");
            
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            
            return NoContent();
        }

        [HttpGet("{transactionId}", Name = "GetTransaction")]
        [Produces("application/json",
            "application/vnd.trade.hateoas+json")]
        public async Task<IActionResult> GetTransaction(Guid transactionId, string fields,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            _logger.LogInformation($"TransactionsController: {nameof(GetTransaction)} was called.");

            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }

            var query = new GetTransactionQuery()
            {
                AccessKey = Guid.Parse(User.FindFirstValue("AccessKey")),
                TransactionId = transactionId
            };
            
            var returnedTransaction = await _mediator.Send(query);

            var shapedTransaction = returnedTransaction
                .ShapeData(fields) as IDictionary<string, object>;

            var includeLinks = parsedMediaType.SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);

            if (includeLinks)
            {
                var links = CreateLinksForTransaction(transactionId, fields);

                shapedTransaction.Add("links", links);
            }

            return Ok(shapedTransaction);
        }

        [HttpPut("{transactionId}", Name = "UpdateTransaction")]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult> UpdateTransaction(Guid transactionId, 
            [FromBody] UpdateTransactionCommandDto commandDto)
        {
            _logger.LogInformation($"TransactionsController: {nameof(UpdateTransaction)} was called.");

            var command = _mapper.Map<UpdateTransactionCommand>(commandDto);
            command.AccessKey = Guid.Parse(User.FindFirstValue("AccessKey"));
            command.TransactionId = transactionId;

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPatch("{transactionId}", Name = "PatchTransaction")]
        [RequestHeaderMatchesMediaType("Content-Type", "application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult> PatchTransaction(Guid transactionId, 
            JsonPatchDocument<UpdateTransactionCommandDto> patchDocument)
        {
            _logger.LogInformation($"TransactionsController: {nameof(PatchTransaction)} was called.");

            var command = new PatchTransactionCommand()
            {
                AccessKey = Guid.Parse(User.FindFirstValue("AccessKey")),
                TransactionId = transactionId,
                PatchDocument = patchDocument
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{transactionId}", Name = "DeleteTransaction")]
        public async Task<ActionResult> DeleteTransaction(Guid transactionId)
        {
            _logger.LogInformation($"TransactionsController: {nameof(DeleteTransaction)} was called.");

            var command = new DeleteTransactionCommand() 
            {
                AccessKey = Guid.Parse(User.FindFirstValue("AccessKey")),
                TransactionId = transactionId
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpOptions("{transactionId}", Name = "OptionsForTransactionById")]
        public IActionResult OptionsForTransactionById()
        {
            _logger.LogInformation($"TransactionsController: {nameof(OptionsForTransactionById)} was called.");

            Response.Headers.Add("Allow", "DELETE,GET,OPTIONS,PATCH,PUT");
            
            return NoContent();
        }

        [HttpGet("export", Name = "ExportTransactions")]
        [FileResultContentType("text/csv")]
        public async Task<IActionResult> ExportTransactions()
        {
            _logger.LogInformation($"TransactionsController: {nameof(ExportTransactions)} was called.");

            var query = new ExportTransactionsQuery()
            {
                AccessKey = Guid.Parse(User.FindFirstValue("AccessKey"))
            };

            var fileExportDto = await _mediator.Send(query);
            return File(
                fileExportDto.Data, 
                fileExportDto.ContentType, 
                fileExportDto.TransactionsExportFileName);
        }

        [HttpOptions("export", Name = "OptionsForExportTransactions")]
        public IActionResult OptionsForExportTransactions()
        {
            _logger.LogInformation($"TransactionsController: {nameof(OptionsForExportTransactions)} was called.");

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

        private IEnumerable<LinkDto> CreateLinksForTransactions(
            GetTransactionsResourceParameters parameters,
            bool hasNext,
            bool hasPrevious)
        {
            var links = new List<LinkDto>();

            links.Add(
                new LinkDto(
                    CreateTransactionsResourceUrl(
                        parameters, 
                        ResourceUriType.CurrentPage),
                    "self",
                    "GET"));

            if (hasNext)
            {
                links.Add(
                    new LinkDto(
                        CreateTransactionsResourceUrl(
                            parameters, 
                            ResourceUriType.NextPage),
                        "nextPage",
                        "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new LinkDto(
                        CreateTransactionsResourceUrl(
                            parameters, 
                            ResourceUriType.PreviousPage),
                        "previousPage",
                        "GET"));
            }

            return links;
        }

        private string CreateTransactionsResourceUrl(
            GetTransactionsResourceParameters parameters,
            ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link(
                        "GetTransactions",
                        new
                        {
                            fields = parameters.Fields,
                            orderBy = parameters.OrderBy,
                            pageNumber = parameters.PageNumber - 1,
                            pageSize = parameters.PageSize,
                            including = parameters.Including,
                            excluding = parameters.Excluding,
                            rangeStart = parameters.RangeStart,
                            rangeEnd = parameters.RangeEnd
                        });

                case ResourceUriType.NextPage:
                    return Url.Link(
                        "GetTransactions",
                        new
                        {
                            fields = parameters.Fields,
                            orderBy = parameters.OrderBy,
                            pageNumber = parameters.PageNumber + 1,
                            pageSize = parameters.PageSize,
                            including = parameters.Including,
                            excluding = parameters.Excluding,
                            rangeStart = parameters.RangeStart,
                            rangeEnd = parameters.RangeEnd
                        });

                case ResourceUriType.CurrentPage:
                default:
                    return Url.Link(
                        "GetTransactions",
                        new
                        {
                            fields = parameters.Fields,
                            orderBy = parameters.OrderBy,
                            pageNumber = parameters.PageNumber,
                            pageSize = parameters.PageSize,
                            including = parameters.Including,
                            excluding = parameters.Excluding,
                            rangeStart = parameters.RangeStart,
                            rangeEnd = parameters.RangeEnd
                        });
            }
        }        
    }
}