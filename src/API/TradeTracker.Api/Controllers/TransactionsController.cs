using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TransactionsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator 
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost(Name = "CreateTransaction")]
        public async Task<ActionResult<Guid>> CreateTransaction([FromBody] CreateTransactionCommandDto commandDto)
        {
            var command = _mapper.Map<CreateTransactionCommand>(commandDto);
            command.AccessKey = User.FindFirstValue("AccessKey");

            var createdTransaction = await _mediator.Send(command);
            
            return CreatedAtAction(
                "GetTransactionById",
                new { id = createdTransaction.TransactionId },
                createdTransaction);
        }

        [HttpGet("{id}", Name = "GetTransactionById")]
        public async Task<ActionResult<TransactionForReturnDto>> GetTransactionById(Guid id)
        {
            var query = new GetTransactionQuery()
            {
                AccessKey = User.FindFirstValue("AccessKey"),
                TransactionId = id
            };
            
            var returnedTransaction = await _mediator.Send(query);
            return Ok(returnedTransaction);
        }

        [HttpGet(Name = "GetTransactions")]
        public async Task<ActionResult<PagedTransactionsDto>> GetTransactions(
            [FromQuery] GetTransactionsResourceParameters parameters)
        {
            var query = _mapper.Map<GetTransactionsQuery>(parameters);
            query.AccessKey = User.FindFirstValue("AccessKey");

            var returnedTransactions = await _mediator.Send(query);
            return Ok(returnedTransactions);
        }

        [HttpPut("{id}", Name = "UpdateTransaction")]
        public async Task<ActionResult> UpdateTransaction(Guid id, [FromBody] UpdateTransactionCommandDto commandDto)
        {
            var command = _mapper.Map<UpdateTransactionCommand>(commandDto);
            command.AccessKey = User.FindFirstValue("AccessKey");
            command.TransactionId = id;

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchTransaction(Guid id, JsonPatchDocument<UpdateTransactionCommandDto> patchDocument)
        {
            var command = new PatchTransactionCommand()
            {
                AccessKey = User.FindFirstValue("AccessKey"),
                TransactionId = id,
                PatchDocument = patchDocument
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTransaction")]
        public async Task<ActionResult> DeleteTransaction(Guid id)
        {
            var command = new DeleteTransactionCommand() 
            {
                AccessKey =User.FindFirstValue("AccessKey"),
                TransactionId = id
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportTransactions")]
        [FileResultContentType("text/csv")]
        public async Task<IActionResult> ExportTransactions()
        {
            var query = new ExportTransactionsQuery()
            {
                AccessKey = User.FindFirstValue("AccessKey")
            };

            var fileExportDto = await _mediator.Send(query);
            return File(
                fileExportDto.Data, 
                fileExportDto.ContentType, 
                fileExportDto.TransactionsExportFileName);
        }

        [HttpOptions(Name = "OptionsTransactions")]
        public IActionResult OptionsTransactions()
        {
            Response.Headers.Add("Allow", "DELETE,GET,OPTIONS,POST,PUT");
            
            return NoContent();
        }
    }
}