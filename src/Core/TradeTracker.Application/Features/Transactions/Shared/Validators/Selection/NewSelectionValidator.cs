using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators.Selection
{
    public class SelectionValidator : AbstractValidator<string>
    {
        public SelectionValidator()
        {
            RuleFor(s => s)
                .Cascade(CascadeMode.Stop)
                .Must(s => hasTwoElements(s))
                    .WithMessage("Selection must include both values and a type.")
                .SetValidator(new SelectionComponentsValidator());
        }

        private bool hasTwoElements(string input)
        {
            var isValid = false;

            var cleanedInput = input.Trim();

            var splitString = cleanedInput
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(s => !String.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToList();

            if (splitString.Count() == 2)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
