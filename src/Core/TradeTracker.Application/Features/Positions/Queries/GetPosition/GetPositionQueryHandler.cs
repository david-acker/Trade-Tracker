using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Exceptions;
using TradeTracker.Application.Common.Interfaces.Infrastructure;
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
        private readonly IPositionService _positionService;

        public GetPositionQueryHandler(
            IAuthenticatedPositionRepository authenticatedPositionRepository,
            IMapper mapper,
            IPositionService positionService)
        {
            _authenticatedPositionRepository = authenticatedPositionRepository;
            _mapper = mapper;
            _positionService = positionService;
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

            positionForReturn.AverageCostBasis = await _positionService
                .CalculateAverageCostBasis( 
                    request.Symbol);

            positionForReturn.SourceRelations = await _positionService
                .CreateSourceRelations(
                    request.Symbol);

            return positionForReturn;
        }
    }
}
