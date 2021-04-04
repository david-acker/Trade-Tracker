using FluentValidation;

namespace TradeTracker.Application.Common.Validation.Pagination
{
    public class PageNumberValidator : AbstractValidator<int>
    {
        public PageNumberValidator()
        {
            RuleFor(t => t)
                .GreaterThan(0)
                    .WithMessage("PageNumber must be greater than zero.");
        }
    }
}
