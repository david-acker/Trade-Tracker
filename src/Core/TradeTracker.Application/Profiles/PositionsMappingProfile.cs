using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TradeTracker.Api.Models.Querying;
using TradeTracker.Application.Enums;
using TradeTracker.Application.Features.Positions;
using TradeTracker.Application.Features.Positions.Queries.GetPositions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Profiles
{
    public class PositionsMappingProfile : Profile
    {
        public PositionsMappingProfile()
        {
            CreateMap<GetPositionsQuery, PagedPositionsResourceParameters>()
                .ForMember(
                        dest => dest.SortOrder,
                        opt => opt.MapFrom(src => new SortOrder(src.Order)))
                    .ForMember(
                            dest => dest.Selection,
                            opt => opt.MapFrom(src =>
                                !String.IsNullOrWhiteSpace(src.Selection)
                                    ? new Selection(src.Selection)
                                    : null));

            CreateMap<Position, PositionForReturnDto>();

            CreateMap<Position, DetailedPositionForReturnDto>();

            CreateMap<PositionForReturnDto, PositionForReturnWithLinksDto>();

            CreateMap<DetailedPositionForReturnDto, DetailedPositionForReturnWithLinksDto>();
        }
    }
}