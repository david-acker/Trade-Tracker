using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeTracker.Api.Utilities;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Features.Transactions.Queries.ExportTransactions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransaction;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactionsList;

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

        [HttpGet(Name = "GetTransactionsList")]
        public async Task<ActionResult<PagedTransactionsListVm>> GetTransactionsList(
            [FromQuery] GetTransactionsListResourceParameters getTransactionsListResourceParameters)
        {
            var query = _mapper.Map<GetTransactionsListQuery>(getTransactionsListResourceParameters);

            query.AccessKey = User.FindFirstValue("AccessKey");

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}", Name = "GetTransactionById")]
        public async Task<ActionResult<TransactionDto>> GetTransactionById(Guid id)
        {
            var query = new GetTransactionQuery()
            {
                AccessKey = User.FindFirstValue("AccessKey"),
                TransactionId = id
            };
            
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(Name = "AddTransaction")]
        public async Task<ActionResult<Guid>> AddTransaction([FromBody] CreateTransactionCommand createTransactionCommand)
        {
            createTransactionCommand.AccessKey = User.FindFirstValue("AccessKey");

            var transactionToReturn = await _mediator.Send(createTransactionCommand);
            
            return CreatedAtAction(
                "GetTransactionById",
                new { id = transactionToReturn.TransactionId },
                transactionToReturn);
        }

        [HttpPut("{id}", Name = "UpdateTransaction")]
        public async Task<ActionResult> UpdateTransaction(Guid id, [FromBody] UpdateTransactionCommand updateTransactionCommand)
        {
            updateTransactionCommand.AccessKey = User.FindFirstValue("AccessKey");
            updateTransactionCommand.TransactionId = id;
            await _mediator.Send(updateTransactionCommand);
            
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTransaction")]
        public async Task<ActionResult> DeleteTransaction(Guid id)
        {
            var command = new DeleteTransactionCommand() 
            {
                AccessKey = User.FindFirstValue("AccessKey"),
                TransactionId = id
            };
            await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpGet("export", Name = "ExportTransactions")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportTransactions()
        {
            var query = new ExportTransactionsQuery()
            {
                AccessKey = User.FindFirstValue("AccessKey")
            };
            var fileDto = await _mediator.Send(query);

            return File(fileDto.Data, fileDto.ContentType, fileDto.TransactionsExportFileName);
        }

        [HttpOptions(Name = "OptionsTransactions")]
        public IActionResult OptionsTransactions()
        {
            Response.Headers.Add("Allow", "DELETE,GET,OPTIONS,POST,PUT");
            
            return NoContent();
        }
    }
}