using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Persistence;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransaction
{
    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, TransactionDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionQueryHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<TransactionDto> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.AccessTag, request.TransactionId);
            var transactionDto = _mapper.Map<TransactionDto>(transaction);

            return transactionDto;
        }
    }
}
