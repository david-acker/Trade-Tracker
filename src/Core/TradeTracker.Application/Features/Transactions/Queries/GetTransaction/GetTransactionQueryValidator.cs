using FluentValidation;
using TradeTracker.Application.Features.Transactions.Shared.Validators;
using TradeTracker.Application.Features.Transactions.Validators.Transactions;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransaction
{
    public class GetTransactionQueryValidator : AbstractValidator<GetTransactionQuery>
    {
        public GetTransactionQueryValidator()
        {
            RuleFor(t => t.AccessKey)
                .SetValidator(new AccessKeyValidator());

            RuleFor(t => t.TransactionId)
                .SetValidator(new TransactionIdValidator());
        }
    }
}