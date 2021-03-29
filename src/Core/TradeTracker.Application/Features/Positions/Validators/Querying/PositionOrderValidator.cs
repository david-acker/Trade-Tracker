using System;
using System.Linq;
using FluentValidation;

namespace TradeTracker.Application.Features.Positions.Validators.Querying
{
    public class PositionOrderValidator : AbstractValidator<string>
    {
        public PositionOrderValidator()
        {
            RuleFor(s => s)
                .Cascade(CascadeMode.Stop)
                .Must(s => hasCorrectNumberOfElements(s, 2))
                    .WithMessage("Selection must include both an OrderBy field and a SortOrder.")
                .SetValidator(new PositionOrderComponentsValidator());
        }

        private bool hasCorrectNumberOfElements(string input, int expectedCount)
        {
            var isValid = false;

            var cleanedInput = input.Trim();

            var splitString = cleanedInput
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(s => !String.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToList();

            if (splitString.Count() == expectedCount)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
