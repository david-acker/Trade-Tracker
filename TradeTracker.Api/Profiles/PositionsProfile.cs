using AutoMapper;
using TradeTracker.Api.DTOs.Position;
using TradeTracker.Core.DomainModels.Position;

namespace TradeTracker.Api.Profiles
{
    public class PositionsProfile : Profile
    {
        public PositionsProfile()
        {
            CreateMap<PositionDomainModel, PositionDto>();

            CreateMap<PositionFilterDto, PositionFilterDomainModel>();
        }
    }
}
