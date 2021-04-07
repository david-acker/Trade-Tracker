using System;
using System.Collections.Generic;
using AutoMapper;
using TradeTracker.Application.Common.Models.Resources.Parameters.Transactions;
using TradeTracker.Application.Common.Models.Resources.Requests;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Features.Transactions.Queries.ExportTransactions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Application.Interfaces.Resources.Requests;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Common.Profiles
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

            CreateMap<Transaction, TransactionForReturn>();
            CreateMap<Transaction, TransactionForReturnWithLinks>();
            CreateMap<TransactionForReturn, TransactionForReturnWithLinks>();

            CreateMap<Transaction, TransactionForExport>();

            CreateMap<GetTransactionsQuery, PagedTransactionsResourceParameters>()
                .ForMember(
                    dest => dest.OrderBy,
                    opt => opt.MapFrom(src => AssignTransactionOrderBy(src.OrderBy)))
                .ForMember(
                        dest => dest.SymbolSelection,
                        opt => opt.MapFrom(src => AssignSymbolSelection(src.SymbolSelection)))
                .ForMember(
                    dest => dest.RangeStart,
                    opt => opt.MapFrom(src => DateTime.Parse(src.RangeStart)))
                .ForMember(
                    dest => dest.RangeEnd,
                    opt => opt.MapFrom(src => DateTime.Parse(src.RangeEnd)));
        }

        private static ITransactionOrderBy AssignTransactionOrderBy(string orderBy)
        {
            if (!String.IsNullOrWhiteSpace(orderBy))
            {
                return new TransactionOrderBy(orderBy);
            }
            else 
            {
                return new NullTransactionOrderBy();
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

