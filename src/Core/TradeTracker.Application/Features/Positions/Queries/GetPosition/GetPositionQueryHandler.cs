using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Exceptions;
using TradeTracker.Application.Common.Interfaces;
using TradeTracker.Application.Common.Interfaces.Persistence.Positions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetPositionQueryHandler : 
        ValidatableRequestBehavior<GetPositionQuery>,
        IRequestHandler<GetPositionQuery, PositionForReturn>
    {
        private readonly IAuthenticatedPositionRepository _authenticatedPositionRepository;
        private readonly IMapper _mapper;
        private readonly ICostBasisCalculator _costBasisCalculator;

        public GetPositionQueryHandler(
            IAuthenticatedPositionRepository authenticatedPositionRepository,
            IMapper mapper,
            ICostBasisCalculator costBasisCalculator)
        {
            _authenticatedPositionRepository = authenticatedPositionRepository;
            _mapper = mapper;
            _costBasisCalculator = costBasisCalculator;
        }

        public async Task<PositionForReturn> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var position = await _authenticatedPositionRepository.GetBySymbolAsync(request.Symbol);

            if (position == null)
            {
                throw new NotFoundException(nameof(Position), request.Symbol);
            }
            
            var positionForReturn = _mapper.Map<PositionForReturn>(position);

            positionForReturn.AverageCostBasis = await _costBasisCalculator
                .CalculateAverageCostBasis( 
                    request.Symbol);

            positionForReturn.SourceRelations = await _costBasisCalculator
                .CreateSourceRelations(
                    request.Symbol);

            return positionForReturn;
        }
    }
}
