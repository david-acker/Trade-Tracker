using AutoMapper;
using TradeTracker.Application.Features.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransaction;
using TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Features.Transactions.Queries.ExportTransactions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
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
        }
    }
}