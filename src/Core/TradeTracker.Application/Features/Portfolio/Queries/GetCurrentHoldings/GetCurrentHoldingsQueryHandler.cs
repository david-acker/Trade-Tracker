using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Persistence;

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
