using AutoMapper;
using TradeTracker.Core.DomainModels.Transaction;
using TradeTracker.Repository.EntityModels.Transaction;

namespace TradeTracker.Repository.Profiles
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            CreateMap<TransactionDomainModel, TransactionEntityModel>()
                .ReverseMap();

            CreateMap<TransactionFilterDomainModel, TransactionFilterEntityModel>();
        }
    }
}
