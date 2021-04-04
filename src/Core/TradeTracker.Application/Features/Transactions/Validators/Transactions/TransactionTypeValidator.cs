using FluentValidation;
using TradeTracker.Application.Common.Helpers;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Features.Transactions.Validators.Transactions
{
    public class TransactionTypeValidator : AbstractValidator<string>
    {
        public TransactionTypeValidator()
        {
            RuleFor(t => t)
                .NotNull()
                .NotEmpty()
                    .WithMessage("TransactionType is required.")
                .IsEnumName(typeof(TransactionType), caseSensitive: false)
                    .WithMessage("A valid TransactionType is required.")
                .Must(t => EnumHelper.IsNotDefault<TransactionType>(t))
                    .WithMessage("TransactionType cannot be left unspecified.");
        }
    }
}
