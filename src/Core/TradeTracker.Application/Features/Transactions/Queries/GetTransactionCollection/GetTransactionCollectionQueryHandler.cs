using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Persistence;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection
{
    public class GetTransactionCollectionQueryHandler 
        : IRequestHandler<GetTransactionCollectionQuery, IEnumerable<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionCollectionQueryHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<IEnumerable<TransactionDto>> Handle(GetTransactionCollectionQuery request, CancellationToken cancellationToken)
        {
            var transactionCollection = await _transactionRepository.GetTransactionCollectionByIds(request.AccessKey, request.TransactionIds);
            var transactionCollectionDto = _mapper.Map<IEnumerable<TransactionDto>>(transactionCollection);

            return transactionCollectionDto;
        }
    }
}
