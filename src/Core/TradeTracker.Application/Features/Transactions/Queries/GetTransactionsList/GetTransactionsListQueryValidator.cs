using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionsList
{
    public class GetTransactionsListQueryValidator : AbstractValidator<GetTransactionsListQuery>
    {
        public GetTransactionsListQueryValidator()
        {
            RuleFor(q => q.AccessKey).SetValidator(new AccessKeyValidator());
        }
    }
}