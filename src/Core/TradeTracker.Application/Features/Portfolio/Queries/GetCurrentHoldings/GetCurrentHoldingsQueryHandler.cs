using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Features.Portfolio.Queries.GetCurrentHoldings
{
    public class GetCurrentHoldingsQueryHandler : IRequestHandler<GetCurrentHoldingsQuery, IEnumerable<HoldingVm>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetCurrentHoldingsQueryHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<IEnumerable<HoldingVm>> Handle(GetCurrentHoldingsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCurrentHoldingsQueryValidator();
            var validationResult = await validator.ValidateAsync(request);
            
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var allTransactions = await _transactionRepository.ListAllAsync(request.AccessKey);

            var currentHoldingsVm = allTransactions
                .GroupBy(t => new { t.Symbol })
                .Select(h => new HoldingVm
                {
                    Symbol = h.Key.Symbol,
                    NetQuantity = h.Sum(x => PortfolioCalculator.CalculateCurrentHolding(x))
                }).OrderByDescending(h => h.NetQuantity);

            return currentHoldingsVm;
        }
        

    }
}
