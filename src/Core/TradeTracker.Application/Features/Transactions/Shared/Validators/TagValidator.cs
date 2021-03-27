using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class TagValidator : AbstractValidator<string>
    {
        public TagValidator()
        {
            RuleFor(t => t)
                .NotNull()
                .NotEmpty()
                    .WithMessage("A Tag cannot be empty or null.")
                .Length(1, 25)
                    .WithMessage("A Tag must be between 1 and 25 characters.");
        }
    }
}