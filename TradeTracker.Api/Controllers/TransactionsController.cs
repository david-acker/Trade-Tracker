using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradeTracker.Business.Services;
using TradeTracker.Core.DomainModels;
using TradeTracker.EntityModels.Models.Transaction;

namespace TradeTracker.Api.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly IMapper _mapper;

        public TransactionsController(
            ITransactionsService transactionsService,
            IMapper mapper)
        {
            _transactionsService = transactionsService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{transactionId}")]
        public async Task<IActionResult> GetAsync(int transactionId)
        {
            var accessKey = Guid.Empty.ToString();

            var transaction = await _transactionsService.GetTransaction(transactionId, accessKey);
            if (transaction == null)
            {
                return NotFound(transactionId);
            }

            var transactionDomainModel = _mapper.Map<TransactionDomainModel>(transaction);

            return Ok(transactionDomainModel);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(TransactionInputDomainModel inputModel)
        {
            var modelState = _transactionsService.ValidateTransaction(inputModel);
            if (!modelState.IsValid)
            {
                return UnprocessableEntity(modelState);
            }

            var transaction = _mapper.Map<Transaction>(inputModel);
            transaction.AccessKey = Guid.Empty.ToString();
            transaction = await _transactionsService.CreateTransaction(transaction);
            
            var transactionDomainModel = _mapper.Map<TransactionDomainModel>(transaction);

            return CreatedAtAction(
                nameof(GetAsync),
                new { transactionId = transactionDomainModel.TransactionId },
                transactionDomainModel);
        }

        [HttpPut]
        [Route("{transactionId}")]
        public async Task<IActionResult> UpdateAsync(int transactionId, TransactionInputDomainModel inputModel)
        {
            var accessKey = Guid.Empty.ToString();

            var transaction = await _transactionsService.GetTransaction(transactionId, accessKey);
            if (transaction == null)
            {
                return NotFound(transactionId);
            }

            var modelState = _transactionsService.ValidateTransaction(inputModel);
            if (!modelState.IsValid)
            {
                return UnprocessableEntity(modelState);
            }

            _mapper.Map(inputModel, transaction, typeof(TransactionInputDomainModel), typeof(Transaction));

            await _transactionsService.UpdateTransaction(transaction);

            return NoContent();
        }

        [HttpDelete]
        [Route("{transactionId}")]
        public async Task<IActionResult> DeleteAsync(int transactionId)
        {
            var accessKey = Guid.Empty.ToString();

            var transaction = await _transactionsService.GetTransaction(transactionId, accessKey);
            if (transaction == null)
            {
                return NotFound(transactionId);
            }

            await _transactionsService.DeleteTransaction(transactionId, accessKey);

            return NoContent();
        }
    }
}
