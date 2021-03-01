using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeTracker.Api.Helpers;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactionsList;

namespace TradeTracker.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionCollectionsController : Controller
    {
        private readonly IMediator _mediator;

        public TransactionCollectionsController(IMediator mediator)
        {
            _mediator = mediator 
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{ids}", Name = "GetTransactionCollectionById")]
        public async Task<ActionResult<PagedTransactionsListVm>> GetTransactionCollectionById(
            [FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var query = new GetTransactionCollectionQuery()
            {
                AccessKey = User.Identity.Name,
                TransactionIds = ids
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpPost(Name = "AddTransactionCollection")]
        public async Task<ActionResult<Guid>> AddTransactionCollection([FromBody] CreateTransactionCollectionCommand command)
        {
            string AccessKey = User.Identity.Name;

            foreach (var transaction in command.Transactions)
            {
                transaction.AccessKey = AccessKey;
            }

            var transactionCollectionToReturn = await _mediator.Send(command);
            
            var idsAsString = String.Join(",", transactionCollectionToReturn.Select(t => t.TransactionId));

            return CreatedAtAction(
                "GetTransactionCollectionById",
                new { ids = idsAsString },
                transactionCollectionToReturn);
        }

        [HttpOptions(Name = "OptionsTransactionCollections")]
        public IActionResult OptionsTransactionCollections()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            
            return NoContent();
        }
    }
}