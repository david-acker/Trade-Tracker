using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class QuantityValidator : AbstractValidator<decimal>
    {
        public QuantityValidator()
        {
            RuleFor(t => t)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Quantity must not be blank.")
                .GreaterThan(0)
                    .WithMessage("Quantity must be greater than zero.");
        }
    }
}
