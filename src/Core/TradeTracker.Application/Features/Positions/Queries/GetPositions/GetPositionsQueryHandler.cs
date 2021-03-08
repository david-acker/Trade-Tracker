using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQueryHandler : IRequestHandler<GetPositionsQuery, IEnumerable<PositionForReturnDto>>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public GetPositionsQueryHandler(IMapper mapper, IPositionRepository positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public async Task<IEnumerable<PositionForReturnDto>> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var positions = await _positionRepository.ListAllAsync(request.AccessKey);
            
            var positionsForReturn = _mapper.Map<IEnumerable<PositionForReturnDto>>(positions);

            return positionsForReturn;
        }

        private async Task ValidateRequest(GetPositionsQuery request)
        {
            var validator = new GetPositionsQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }  
        }
    }
}
