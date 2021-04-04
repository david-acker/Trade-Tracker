using FluentValidation;

namespace TradeTracker.Application.Common.Validation.Pagination
{
    public class PageSizeValidator : AbstractValidator<int>
    {
        public PageSizeValidator()
        {
            RuleFor(t => t)
                .GreaterThan(0)
                    .WithMessage("PageSize must be greater than zero.")
                .LessThanOrEqualTo(50)
                    .WithMessage("PageSize cannot exceed 50.");
        }
    }
}
