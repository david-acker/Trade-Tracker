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
                    .WithMessage("Tags cannot be empty or null.")
                .Length(1, 25)
                    .WithMessage("Tags must be between 1 and 25 characters.");
        }
    }
}