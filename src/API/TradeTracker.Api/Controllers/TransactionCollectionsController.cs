using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TransactionCollectionsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator 
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{ids}", Name = "GetTransactionCollectionById")]
        public async Task<ActionResult<PagedTransactionsListVm>> GetTransactionCollectionById(
            [FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var query = new GetTransactionCollectionQuery()
            {
                AccessKey = User.FindFirstValue("AccessKey"),
                TransactionIds = ids
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpPost(Name = "AddTransactionCollection")]
        public async Task<ActionResult<Guid>> AddTransactionCollection(
            [FromBody] CreateTransactionCollectionCommandDto createTransactionCollectionCommandDto)
        {
            var command = _mapper.Map<CreateTransactionCollectionCommand>(createTransactionCollectionCommandDto);

            string AccessKey = User.FindFirstValue("AccessKey");
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