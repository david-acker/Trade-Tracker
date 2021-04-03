using FluentValidation;
using TradeTracker.Application.Common.Helpers;

namespace TradeTracker.Application.Common.Validation.Selection
{
    public class SymbolSelectionValidator : AbstractValidator<string>
    {
        public SymbolSelectionValidator()
        {
            RuleFor(s => s)
                .Cascade(CascadeMode.Stop)
                .Must(s => StringHelper.containsNumberOfElementsAfterSplit(s, 2, ' '))
                    .WithMessage("SymbolSelection must include both Symbols and a SelectionType.")
                .SetValidator(new SymbolSelectionComponentsValidator());
        }
    }
}
