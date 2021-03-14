using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetPositionQueryHandler : IRequestHandler<GetPositionQuery, PositionForReturnDto>
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly IPositionService _positionService;

        public GetPositionQueryHandler(
            IMapper mapper, 
            IPositionRepository positionRepository,
            IPositionService positionService)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
            _positionService = positionService;
        }

        public async Task<PositionForReturnDto> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var position = await _positionRepository.GetBySymbolAsync(request.AccessKey, request.Symbol);

            if (position == null)
            {
                throw new NotFoundException(nameof(Position), request.Symbol);
            }
            
            var positionForReturn = _mapper.Map<PositionForReturnDto>(position);

            positionForReturn.AverageCostBasis = await _positionService
                .CalculateAverageCostBasis(
                    request.AccessKey, 
                    request.Symbol);

            return positionForReturn;
        }

        private async Task ValidateRequest(GetPositionQuery request)
        {
            var validator = new GetPositionQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }  
        }
    }
}
