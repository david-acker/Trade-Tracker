using AutoMapper;
using TradeTracker.Core.DomainModels;
using TradeTracker.EntityModels.Models.Transaction;

namespace TradeTracker.Api.Profiles
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            CreateMap<Transaction, TransactionDomainModel>();

            CreateMap<TransactionInputDomainModel, Transaction>()
                .ForMember(dest => dest.TransactionId, opt => opt.Ignore())
                .ForMember(dest => dest.AccessKey, opt => opt.Ignore());
        }
    }
}
