using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
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
        private readonly IPositionRepository _positionRepository;
        private readonly IPositionService _positionService;

        public GetPositionQueryHandler(
            ILoggedInUserService loggedInUserService,
            IMapper mapper, 
            IPositionRepository positionRepository,
            IPositionService positionService)
        {
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
            _positionRepository = positionRepository;
            _positionService = positionService;
        }

        public async Task<PositionForReturnDto> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var userAccessKey = _loggedInUserService.AccessKey;

            var position = await _positionRepository.GetBySymbolAsync(userAccessKey, request.Symbol);

            if (position == null)
            {
                throw new NotFoundException(nameof(Position), request.Symbol);
            }
            
            var positionForReturn = _mapper.Map<PositionForReturnDto>(position);

            positionForReturn.AverageCostBasis = await _positionService
                .CalculateAverageCostBasis(
                    userAccessKey, 
                    request.Symbol);

            positionForReturn.SourceTransactionMap = await _positionService
                .CreateSourceTransactionMap(
                    userAccessKey,
                    request.Symbol);

            return positionForReturn;
        }
    }
}
