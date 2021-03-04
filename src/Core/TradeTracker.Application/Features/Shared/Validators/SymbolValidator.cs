using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class SymbolValidator : AbstractValidator<string>
    {
        public SymbolValidator()
        {
            RuleFor(t => t)
                .NotNull()
                .NotEmpty()
                    .WithMessage("The Symbol must not be blank.")
                .MaximumLength(12)
                    .WithMessage("The Symbol must not exceed 12 characters.");
        }
    }
}
