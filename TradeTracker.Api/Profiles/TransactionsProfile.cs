using AutoMapper;
using TradeTracker.Api.DTOs.Transaction;
using TradeTracker.Core.DomainModels.Transaction;

namespace TradeTracker.Api.Profiles
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            CreateMap<TransactionDomainModel, TransactionDto>();

            CreateMap<TransactionInputDto, TransactionDomainModel>()
                .ForMember(dest => dest.TransactionId, opt => opt.Ignore())
                .ForMember(dest => dest.AccessKey, opt => opt.Ignore());

            CreateMap<TransactionFilterDto, TransactionFilterDomainModel>();
        }
    }
}
