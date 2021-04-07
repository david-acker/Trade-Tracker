using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Exceptions;
using TradeTracker.Application.Common.Interfaces.Infrastructure;
using TradeTracker.Application.Common.Interfaces.Persistence.Positions;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetDetailedPositionQueryHandler : 
        ValidatableRequestBehavior<GetDetailedPositionQuery>,
        IRequestHandler<GetDetailedPositionQuery, DetailedPositionForReturn>
    {     
        private readonly IAuthenticatedPositionRepository _authenticatedPositionRepository;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly IMapper _mapper;
        private readonly IPositionService _positionService;

        public GetDetailedPositionQueryHandler(
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            IAuthenticatedPositionRepository authenticatedPositionRepository,
            IMapper mapper,
            IPositionService positionService)
        {
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _authenticatedPositionRepository = authenticatedPositionRepository;
            _mapper = mapper;
            _positionService = positionService;
        }

        public async Task<DetailedPositionForReturn> Handle(GetDetailedPositionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var position = await _authenticatedPositionRepository.GetBySymbolAsync(request.Symbol);

            if (position == null)
            {
                throw new NotFoundException(nameof(Position), request.Symbol);
            }
            
            var positionForReturn = _mapper.Map<DetailedPositionForReturn>(position);

            positionForReturn.AverageCostBasis = await _positionService
                .CalculateAverageCostBasis(
                    request.Symbol);

            var sourceRelations = await _positionService
                .CreateSourceRelations(
                    request.Symbol);

            var tasks = sourceRelations
                .Select(async (sourceLink) => await CreateFullLink(sourceLink))
                .ToList();

            var fullSourceRelations = await Task.WhenAll(tasks);

            positionForReturn.SourceRelations = fullSourceRelations;

            return positionForReturn;
        }

        private async Task<FullSourceRelation> CreateFullLink(
            SourceRelation sourceLink)
        {
            var transaction = await _authenticatedTransactionRepository
                .GetByIdAsync(sourceLink.TransactionId);

            var transactionWithLinks = 
                _mapper.Map<TransactionForReturnWithLinks>(transaction);

            return new FullSourceRelation(sourceLink, transactionWithLinks);
        } 
    }
}
