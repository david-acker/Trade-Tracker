using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection
{
    public class CreateTransactionCollectionCommandHandler :
        ValidatableRequestBehavior<CreateTransactionCollectionCommand>,
        IRequestHandler<CreateTransactionCollectionCommand, IEnumerable<TransactionForReturnDto>>
    {
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly IMapper _mapper;
        
        public CreateTransactionCollectionCommandHandler(
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            IMapper mapper)
        {
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionForReturnDto>> Handle(
            CreateTransactionCollectionCommand request, 
            CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transactionCollection = _mapper.Map<IEnumerable<Transaction>>(request.Transactions);

            transactionCollection = await _authenticatedTransactionRepository.AddRangeAsync(transactionCollection);

            return _mapper.Map<IEnumerable<TransactionForReturnDto>>(transactionCollection);
        }
    }
}