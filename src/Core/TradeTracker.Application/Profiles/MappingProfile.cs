using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TradeTracker.Application.Features.Positions;
using TradeTracker.Application.Features.Positions.Queries.GetPositions;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Features.Transactions.Queries.ExportTransactions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTransactionCommandDto, CreateTransactionCommand>();

            CreateMap<TransactionForCreationDto, TransactionForCreationCommandBase>();

            CreateMap<TransactionForCreationCommandBase, Transaction>();

            CreateMap<CreateTransactionCollectionCommand, IEnumerable<Transaction>>();

            CreateMap<Transaction, CreateTransactionCommand>()
                .ForMember(
                    dest => dest.AccessKey,
                    opt => opt.MapFrom(src => src.AccessKey))
                .ReverseMap();

            CreateMap<UpdateTransactionCommandDto, UpdateTransactionCommand>();

            CreateMap<Transaction, UpdateTransactionCommand>()
                .ReverseMap();

            CreateMap<Transaction, TransactionsForExportDto>()
                .ReverseMap(); 

            CreateMap<Transaction, TransactionForReturnDto>()
                .ReverseMap();

            CreateMap<Transaction, CreateTransactionCollectionCommand>()
                .ReverseMap();

            CreateMap<GetPagedTransactionsResourceParameters, GetTransactionsQuery>()
                .ForMember(
                    dest => dest.RangeStart,
                    opt => opt.MapFrom(src => (DateTime.Parse(src.RangeStart))))
                .ForMember(
                    dest => dest.RangeEnd,
                    opt => opt.MapFrom(src => (DateTime.Parse(src.RangeEnd))))
                .ForMember(
                    dest => dest.Including,
                    opt => opt.MapFrom(src => 
                        (src.Including != null)
                            ? ArraySelectionParser(src.Including)
                            : new List<string>()))
                .ForMember(
                    dest => dest.Excluding,
                    opt => opt.MapFrom(src => 
                        (src.Excluding != null)
                            ? ArraySelectionParser(src.Excluding)
                            : new List<string>()));

            CreateMap<GetTransactionsQuery, PagedTransactionsResourceParameters>();

            CreateMap<TransactionForReturnDto, TransactionForReturnWithLinksDto>();

            CreateMap<GetPositionsResourceParameters, GetPositionsQuery>()
                .ForMember(
                    dest => dest.Including,
                    opt => opt.MapFrom(src => 
                        (src.Including != null)
                            ? ArraySelectionParser(src.Including)
                            : new List<string>()))
                .ForMember(
                    dest => dest.Excluding,
                    opt => opt.MapFrom(src => 
                        (src.Excluding != null)
                            ? ArraySelectionParser(src.Excluding)
                            : new List<string>()));
                
            CreateMap<GetPositionsQuery, PagedPositionsResourceParameters>();

            CreateMap<Position, PositionForReturnDto>();
        }

        private List<string> ArraySelectionParser(string input)
        {
            char[] boundaryCharacters = { '(', ')' };

            return input.Trim(boundaryCharacters).Split(',').ToList();
        }
    }
}