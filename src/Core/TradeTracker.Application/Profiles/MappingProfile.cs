using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

            CreateMap<Transaction, CreateTransactionCommand>()
                .ForMember(
                    dest => dest.AccessKey,
                    opt => opt.MapFrom(src => src.AccessKey))
                .ReverseMap();

            CreateMap<CreateTransactionCollectionCommandDto, CreateTransactionCollectionCommand>();

            CreateMap<UpdateTransactionCommandDto, UpdateTransactionCommand>();

            CreateMap<Transaction, UpdateTransactionCommand>()
                .ForMember(
                    dest => dest.AccessKey,
                    opt => opt.MapFrom(src => src.AccessKey))
                .ReverseMap();

            CreateMap<Transaction, TransactionsForExportDto>()
                .ReverseMap(); 

            CreateMap<Transaction, TransactionForReturnDto>()
                .ReverseMap();

            CreateMap<Transaction, CreateTransactionCollectionCommand>()
                .ReverseMap();

            CreateMap<GetTransactionsResourceParameters, GetTransactionsQuery>()
                .ForMember(
                    dest => dest.RangeStart,
                    opt => opt.MapFrom(src => DateTime.Parse(src.RangeStart)))
                .ForMember(
                    dest => dest.RangeEnd,
                    opt => opt.MapFrom(src => DateTime.Parse(src.RangeEnd)))
                .ForMember(
                    dest => dest.Including,
                    opt => opt.MapFrom(src => ArraySelectionParser(src.Including)))
                .ForMember(
                    dest => dest.Excluding,
                    opt => opt.MapFrom(src => ArraySelectionParser(src.Excluding)));

            CreateMap<GetTransactionsQuery, GetPagedTransactionsResourceParameters>();
        }

        private List<string> ArraySelectionParser(string input)
        {
            char[] boundaryCharacters = { '(', ')' };

            return input.Trim(boundaryCharacters).Split(',').ToList();
        }
    }
}