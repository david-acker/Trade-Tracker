using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeTracker.Api.Helpers;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection;

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
        public async Task<ActionResult<IEnumerable<TransactionForReturnDto>>> GetTransactionCollectionById(
            [FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var accessKey = User.FindFirstValue("AccessKey");
            if (accessKey == null)
            {
                return Unauthorized();
            }

            var query = new GetTransactionCollectionQuery()
            {
                AccessKey = accessKey,
                TransactionIds = ids
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpPost(Name = "CreateTransactionCollection")]
        public async Task<ActionResult<Guid>> CreateTransactionCollection(
            [FromBody] CreateTransactionCollectionCommandDto createTransactionCollectionCommandDto)
        {
            var accessKey = User.FindFirstValue("AccessKey");
            if (accessKey == null)
            {
                return Unauthorized();
            }

            var command = _mapper.Map<CreateTransactionCollectionCommand>(createTransactionCollectionCommandDto);

            foreach (var transaction in command.Transactions)
            {
                transaction.AccessKey = accessKey;
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