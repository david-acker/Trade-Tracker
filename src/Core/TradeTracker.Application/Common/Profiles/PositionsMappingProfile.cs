using System;
using AutoMapper;
using TradeTracker.Application.Common.Models.Resources.Parameters.Positions;
using TradeTracker.Application.Common.Models.Resources.Requests;
using TradeTracker.Application.Features.Positions;
using TradeTracker.Application.Features.Positions.Queries.GetPositions;
using TradeTracker.Application.Interfaces.Resources.Requests;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Common.Profiles
{
    public class PositionsMappingProfile : Profile
    {
        public PositionsMappingProfile()
        {
            CreateMap<GetPositionsQuery, PagedPositionsResourceParameters>()
                .ForMember(
                        dest => dest.OrderBy,
                        opt => opt.MapFrom(src => AssignPositionOrderBy(src.OrderBy)))
                    .ForMember(
                            dest => dest.SymbolSelection,
                            opt => opt.MapFrom(src => AssignSymbolSelection(src.SymbolSelection)));

            CreateMap<Position, PositionForReturn>();
            CreateMap<Position, DetailedPositionForReturn>();

            CreateMap<PositionForReturn, PositionForReturnWithLinks>();
            CreateMap<DetailedPositionForReturn, DetailedPositionForReturnWithLinks>();
        }

        private static IPositionOrderBy AssignPositionOrderBy(string orderBy)
        {
            if (!String.IsNullOrWhiteSpace(orderBy))
            {
                return new PositionOrderBy(orderBy);
            }
            else 
            {
                return new NullPositionOrderBy();
            }
        }

        private static ISymbolSelection AssignSymbolSelection(string symbolSelection)
        {
            if (!String.IsNullOrWhiteSpace(symbolSelection))
            {
                return new SymbolSelection(symbolSelection);
            }
            else 
            {
                return new NullSymbolSelection();
            }
        }
    }
}