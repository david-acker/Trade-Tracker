using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Interfaces.Persistence.Positions;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetPositionQueryHandler : 
        ValidatableRequestHandler<GetPositionQuery>,
        IRequestHandler<GetPositionQuery, PositionForReturnDto>
    {
        private readonly ILoggedInUserService _loggedInUserService;   
        private readonly IMapper _mapper;
        private readonly IAuthenticatedPositionRepository _authenticatedPositionRepository;
        private readonly IPositionService _positionService;

        public GetPositionQueryHandler(
            ILoggedInUserService loggedInUserService,
            IMapper mapper,
            IAuthenticatedPositionRepository authenticatedPositionRepository,
            IPositionService positionService)
        {
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
            _authenticatedPositionRepository = authenticatedPositionRepository;
            _positionService = positionService;
        }

        public async Task<PositionForReturnDto> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var position = await _authenticatedPositionRepository.GetBySymbolAsync(request.Symbol);

            if (position == null)
            {
                throw new NotFoundException(nameof(Position), request.Symbol);
            }
            
            var positionForReturn = _mapper.Map<PositionForReturnDto>(position);

            positionForReturn.AverageCostBasis = await _positionService
                .CalculateAverageCostBasis( 
                    request.Symbol);

            positionForReturn.SourceTransactionMap = await _positionService
                .CreateSourceTransactionMap(
                    request.Symbol);

            return positionForReturn;
        }
    }
}
