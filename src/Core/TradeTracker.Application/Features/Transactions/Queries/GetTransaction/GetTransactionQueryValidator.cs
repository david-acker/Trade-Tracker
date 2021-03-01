using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransaction
{
    public class GetTransactionQueryValidator : AbstractValidator<GetTransactionQuery>
    {
        public GetTransactionQueryValidator()
        {
            RuleFor(t => t.AccessKey).SetValidator(new AccessKeyValidator());
        }
    }
}