using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class SymbolStringValidator : AbstractValidator<string>
    {
        public SymbolStringValidator()
        {
            RuleFor(s => s)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Symbols cannot be blank.")
                .MinimumLength(1)
                    .WithMessage("All Symbols must be least 1 character.")
                .MaximumLength(20)
                    .WithMessage("Any Symbol cannot exceed 12 characters.")
                .Matches("^[a-zA-Z0-9]*$")
                    .WithMessage("Symbols must include at least one letter or number.")
                .Matches("^[a-zA-Z0-9.]*$")
                    .WithMessage("Symbols may only include letters, numbers, and periods.");
        }
    }
}