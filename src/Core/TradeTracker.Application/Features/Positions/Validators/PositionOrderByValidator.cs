using FluentValidation;
using TradeTracker.Application.Common.Helpers;

namespace TradeTracker.Application.Features.Positions.Validators
{
    public class PositionOrderByValidator : AbstractValidator<string>
    {
        public PositionOrderByValidator()
        {
            RuleFor(s => s)
                .Cascade(CascadeMode.Stop)
                .Must(s => StringHelper.containsNumberOfElementsAfterSplit(s, 2, ' '))
                    .WithMessage("OrderBy must include both a Field and a SortOrder.")
                .SetValidator(new PositionOrderByComponentsValidator());
        }
    }
}
