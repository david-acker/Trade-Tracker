using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Features.Transactions.Queries.ExportTransactions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactionsList;
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

            CreateMap<Transaction, TransactionForCreationDto>()
                .ReverseMap();

            CreateMap<Transaction, UpdateTransactionCommand>()
                .ForMember(
                    dest => dest.AccessKey,
                    opt => opt.MapFrom(src => src.AccessKey))
                .ReverseMap();

            CreateMap<Transaction, TransactionsForExportDto>()
                .ReverseMap(); 

            CreateMap<Transaction, TransactionDto>()
                .ReverseMap();

            CreateMap<Transaction, CreateTransactionCollectionCommand>()
                .ReverseMap();

            CreateMap<GetTransactionsListResourceParameters, GetTransactionsListQuery>()
                .ForMember(
                    dest => dest.StartRange,
                    opt => opt.MapFrom(src => DateTime.Parse(src.StartRange)))
                .ForMember(
                    dest => dest.EndRange,
                    opt => opt.MapFrom(src => DateTime.Parse(src.EndRange)))
                .ForMember(
                    dest => dest.Including,
                    opt => opt.MapFrom(src => ArraySelectionParser(src.Including)))
                .ForMember(
                    dest => dest.Excluding,
                    opt => opt.MapFrom(src => ArraySelectionParser(src.Excluding)));

            CreateMap<GetTransactionsListQuery, GetPagedTransactionsListResourceParameters>();
        }

        private List<string> ArraySelectionParser(string input)
        {
            char[] boundaryCharacters = { '(', ')' };

            return input.Trim(boundaryCharacters).Split(',').ToList();
        }
    }
}