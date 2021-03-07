using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeTracker.Api.Utilities;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction;
using TradeTracker.Application.Features.Transactions.Commands.PatchTransaction;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Features.Transactions.Queries.ExportTransactions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransaction;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;

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
        public async Task<ActionResult<PagedTransactionsDto>> GetTransactions(
            [FromQuery] GetTransactionsResourceParameters parameters)
        {
            _logger.LogInformation($"TransactionsController: {nameof(GetTransactions)} was called.");

            var query = _mapper.Map<GetTransactionsQuery>(parameters);
            query.AccessKey = Guid.Parse(User.FindFirstValue("AccessKey"));

            var returnedTransactions = await _mediator.Send(query);
            return Ok(returnedTransactions);
        }

        [HttpPost(Name = "CreateTransaction")]
        public async Task<ActionResult<TransactionForReturnDto>> CreateTransaction([FromBody] CreateTransactionCommandDto commandDto)
        {
            _logger.LogInformation($"TransactionsController: {nameof(CreateTransaction)} was called.");

            var command = _mapper.Map<CreateTransactionCommand>(commandDto);
            command.AccessKey = Guid.Parse(User.FindFirstValue("AccessKey"));

            var createdTransaction = await _mediator.Send(command);
            
            return CreatedAtAction(
                "GetTransaction",
                new { transactionId = createdTransaction.TransactionId },
                createdTransaction);
        }

        [HttpOptions(Name = "OptionsForTransactions")]
        public IActionResult OptionsForTransactions()
        {
            _logger.LogInformation($"TransactionsController: {nameof(OptionsForTransactions)} was called.");
            
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            
            return NoContent();
        }

        [HttpGet("{transactionId}", Name = "GetTransaction")]
        public async Task<ActionResult<TransactionForReturnDto>> GetTransaction(Guid transactionId)
        {
            _logger.LogInformation($"TransactionsController: {nameof(GetTransaction)} was called.");

            var query = new GetTransactionQuery()
            {
                AccessKey = Guid.Parse(User.FindFirstValue("AccessKey")),
                TransactionId = transactionId
            };
            
            var returnedTransaction = await _mediator.Send(query);
            return Ok(returnedTransaction);
        }

        [HttpPut("{transactionId}", Name = "UpdateTransaction")]
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
        public async Task<ActionResult> PatchTransaction(Guid transactionId, JsonPatchDocument<UpdateTransactionCommandDto> patchDocument)
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


        // private IEnumerable<LinkDto> CreateLinksForTransaction(Guid transactionId)
        // {
        //     var links = new List<LinkDto>()
        //     {
        //         new LinkDto(
        //             Url.Link(
        //                 "GetTransaction",
        //                 new { transactionId }),
        //             "self",
        //             "GET"),

        //         new LinkDto(
        //             Url.Link(
        //                 "UpdateTransaction",
        //                 new { transactionId }),
        //             "update transaction",
        //             "PUT"),
                
        //         new LinkDto(
        //             Url.Link(
        //                 "PatchTransaction",
        //                 new { transactionId }),
        //             "patch transaction",
        //             "PATCH"),

        //         new LinkDto(
        //             Url.Link(
        //                 "DeleteTransaction",
        //                 new { transactionId }),
        //             "delete transaction",
        //             "DELETE")
        //     };

        //     return links;
        // }
    }
}