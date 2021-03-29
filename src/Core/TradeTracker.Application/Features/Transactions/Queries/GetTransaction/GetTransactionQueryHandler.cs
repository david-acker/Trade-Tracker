using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Requests.ValidatedRequestHandler;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransaction
{
    public class GetTransactionQueryHandler : 
        ValidatableRequestHandler<GetTransactionQuery, GetTransactionQueryValidator>,
        IRequestHandler<GetTransactionQuery, TransactionForReturnDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionQueryHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionForReturnDto> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transaction = await _transactionRepository.GetByIdAsync(request.AccessKey, request.TransactionId);
            
            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }
            
            var transactionForReturnDto = _mapper.Map<TransactionForReturnDto>(transaction);

            return transactionForReturnDto;
        }
    }
}
