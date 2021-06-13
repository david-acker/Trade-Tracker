using AutoMapper;
using TradeTracker.Core.DomainModels;
using TradeTracker.EntityModels.Models.Position;

namespace TradeTracker.Api.Profiles
{
    public class PositionsProfile : Profile
    {
        public PositionsProfile()
        {
            CreateMap<Position, PositionDomainModel>();
        }
    }
}
