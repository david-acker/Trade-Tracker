using FluentValidation;

namespace TradeTracker.Application.Features
{
    public class AccessKeyValidator : AbstractValidator<string>
    {
        public AccessKeyValidator()
        {
            RuleFor(a => a)
                .NotNull()
                .NotEmpty()
                    .WithMessage("An {PropertyName} must be provided.");
        }
    }
}