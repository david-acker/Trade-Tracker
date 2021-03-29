using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Validators.Transactions
{
    public class SymbolValidator : AbstractValidator<string>
    {
        public SymbolValidator()
        {
            RuleFor(t => t)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Symbol must not be blank.")
                .MinimumLength(1)
                    .WithMessage("Symbol must be least 1 character.")
                .MaximumLength(12)
                    .WithMessage("Symbol must not exceed 12 characters.");
        }
    }
}
