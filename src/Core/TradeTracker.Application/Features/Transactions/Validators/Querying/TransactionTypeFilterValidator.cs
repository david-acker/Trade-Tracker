using FluentValidation;
using TradeTracker.Application.Common.Helpers;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Features.Transactions.Validators.Querying
{
    public class TransactionTypeFilterValidator : AbstractValidator<string>
    {
        public TransactionTypeFilterValidator()
        {
            RuleFor(t => t)
                .Must(t => EnumHelper.IsNotDefault<TransactionType>(t))
                    .WithMessage("Cannot filter with an invalid TransactionType.");
        }
    }
}