using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TradeTracker.Api.Models.Querying;
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
    public class TransactionsMappingProfile : Profile
    {
        public TransactionsMappingProfile()
        {
            CreateMap<CreateTransactionCommandBase, Transaction>();
            CreateMap<CreateTransactionCommand, Transaction>();
            CreateMap<CreateTransactionCollectionCommand, IEnumerable<Transaction>>();

            CreateMap<Transaction, UpdateTransactionCommand>()
                .ReverseMap();

            CreateMap<Transaction, TransactionsForExportDto>();

            CreateMap<Transaction, TransactionForReturnDto>();
            CreateMap<Transaction, TransactionForReturnWithLinksDto>();
            CreateMap<TransactionForReturnDto, TransactionForReturnWithLinksDto>();

            CreateMap<Transaction, CreateTransactionCollectionCommand>()
                .ReverseMap();

            CreateMap<GetTransactionsQuery, PagedTransactionsResourceParameters>()
                .ForMember(
                    dest => dest.SortOrder,
                    opt => opt.MapFrom(src => new SortOrder(src.Order)))
                .ForMember(
                        dest => dest.Selection,
                        opt => opt.MapFrom(src =>
                            !String.IsNullOrWhiteSpace(src.Selection)
                                ? new Selection(src.Selection)
                                : null))
                .ForMember(
                    dest => dest.RangeStart,
                    opt => opt.MapFrom(src => DateTime.Parse(src.RangeStart)))
                .ForMember(
                    dest => dest.RangeEnd,
                    opt => opt.MapFrom(src => DateTime.Parse(src.RangeEnd)));
        }
    }
}