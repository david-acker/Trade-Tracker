using FluentValidation;
using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Common.Helpers;

namespace TradeTracker.Application.Common.Validation.Selection
{
    public class SymbolSelectionComponentsValidator : AbstractValidator<string>
    {
        public SymbolSelectionComponentsValidator()
        {
            RuleForEach(s => SymbolSelectionParser.ExtractSymbols(s, ' ', ','))
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                    .WithMessage("SymbolSelection symbols may not be blank.")
                .MinimumLength(1)
                    .WithMessage("SymbolSelection symbols must be least 1 character.")
                .MaximumLength(20)
                    .WithMessage("SymbolSelection symbols may not exceed 12 characters.")
                .Matches(@"^[a-zA-Z0-9]*$")
                    .WithMessage("SymbolSelection symbols must include at least one letter or number.")
                .Matches(@"^[a-zA-Z0-9.]*$")
                    .WithMessage("SymbolSelection symbols may only include letters, numbers, and periods.");
        
            RuleFor(s => SymbolSelectionParser.ExtractSelectionTypeString(s, ' '))
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                    .WithMessage("SymbolSelection requires a SelectionType.")
                .IsEnumName(typeof(SelectionType), caseSensitive: false)
                    .WithMessage("SymbolSelection requires a valid SelectionType is required: include, exclude.")
                .Must(t => EnumHelper.IsNotDefault<SelectionType>(t))
                    .WithMessage("SymbolSelection must specify a SelectionType.");
        }
    }
}