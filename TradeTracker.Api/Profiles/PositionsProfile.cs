using AutoMapper;
using TradeTracker.Api.DTOs.Position;
using TradeTracker.Api.DTOs.Transaction;
using TradeTracker.Business.AuxiliaryModels;
using TradeTracker.Core.DomainModels.Position;
using TradeTracker.Core.DomainModels.Transaction;

namespace TradeTracker.Api.Profiles
{
    public class PositionsProfile : Profile
    {
        public PositionsProfile()
        {
            CreateMap<PositionDomainModel, PositionDto>();

            CreateMap<PositionFilterDto, PositionFilterDomainModel>();

            CreateMap<PaginatedResult<PositionDomainModel>, PaginatedResult<PositionDto>>();
        }
    }
}
