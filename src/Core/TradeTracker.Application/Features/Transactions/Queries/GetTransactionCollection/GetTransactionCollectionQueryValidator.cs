using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection
{
    public class GetTransactionCollectionValidator : AbstractValidator<GetTransactionCollectionQuery>
    {
        public GetTransactionCollectionValidator()
        {
            RuleFor(t => t.AccessKey).SetValidator(new AccessKeyValidator());
        }
    }
}