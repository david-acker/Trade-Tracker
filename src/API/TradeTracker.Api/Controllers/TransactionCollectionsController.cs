using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeTracker.Api.Helpers;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection;

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
        public async Task<ActionResult<IEnumerable<TransactionForReturnDto>>> CreateTransactionCollection(
            [FromBody] IEnumerable<TransactionForCreationDto> commandDtos)
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(CreateTransactionCollection)} was called.");

            var command = new CreateTransactionCollectionCommand()
            {
                Transactions = _mapper.Map<IEnumerable<TransactionForCreationCommandBase>>(commandDtos)
            };
            
            var accessKey = Guid.Parse(User.FindFirstValue("AccessKey"));
            foreach (var transaction in command.Transactions)
            {
                transaction.AccessKey = accessKey;
            }

            var transactionCollectionToReturn = await _mediator.Send(command);
            
            var idsAsString = String.Join(",", transactionCollectionToReturn.Select(t => t.TransactionId));

            return CreatedAtAction(
                "GetTransactionCollection",
                new { transactionIds = idsAsString },
                transactionCollectionToReturn);
        }

        [HttpOptions(Name = "OptionsForTransactionCollections")]
        public IActionResult OptionsForTransactionCollections()
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(OptionsForTransactionCollections)} was called.");

            Response.Headers.Add("Allow", "OPTIONS,POST");
            
            return NoContent();
        }

        [HttpGet("{transactionIds}", Name = "GetTransactionCollection")]
        [ActionName("GetTransactionCollection")]
        public async Task<ActionResult<IEnumerable<TransactionForReturnDto>>> GetTransactionCollection(
            [FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> transactionIds)
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(GetTransactionCollection)} was called.");

            var query = new GetTransactionCollectionQuery()
            {
                AccessKey = Guid.Parse(User.FindFirstValue("AccessKey")),
                TransactionIds = transactionIds
            };

            return Ok(await _mediator.Send(query));
        }

        [HttpOptions("{transactionIds}", Name = "OptionsForTransactionCollectionByTransactionIds")]
        public IActionResult OptionsForTransactionCollectionByTransactionIds()
        {
            _logger.LogInformation($"TransactionCollectionsController: {nameof(OptionsForTransactionCollectionByTransactionIds)} was called.");

            Response.Headers.Add("Allow", "GET,OPTIONS");
            
            return NoContent();
        }
    }
}