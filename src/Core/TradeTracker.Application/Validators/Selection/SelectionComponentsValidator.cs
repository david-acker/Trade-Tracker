using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using TradeTracker.Application.Enums;

namespace TradeTracker.Application.Validators.Selection
{
    public class SelectionComponentsValidator : AbstractValidator<string>
    {
        public SelectionComponentsValidator()
        {
            RuleForEach(s => extractValuesComponent(s))
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Selection values must be provided.")
                .MinimumLength(1)
                    .WithMessage("Selection values must be least 1 character.")
                .MaximumLength(20)
                    .WithMessage("Selection values may not exceed 12 characters.")
                .Matches(@"^[a-zA-Z0-9]*$")
                    .WithMessage("Selection values must include at least one letter or number.")
                .Matches(@"^[a-zA-Z0-9.]*$")
                    .WithMessage("Selection values may only include letters, numbers, and periods.");
        
            RuleFor(s => extractTypeComponent(s))
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                    .WithMessage("A Selection type must be provided.")
                .IsEnumName(typeof(SelectionType), caseSensitive: false)
                    .WithMessage("A valid Selection type is required: include, exclude.")
                .Must(t => IsSelectionTypeSpecified(t))
                    .WithMessage("The Selection type cannot be left unspecified.");
        }
               
        private List<string> extractValuesComponent(string input)
        {
            var cleanedInput = input.Trim();

            var valuesString = cleanedInput
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]
                .Trim();

            return valuesString
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Where(s => !String.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToList();
        }

        private string extractTypeComponent(string input)
        {
            var cleanedInput = input.Trim();

            return cleanedInput
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]
                .Trim();
        }

        private bool IsSelectionTypeSpecified(string input)
        {   
            var isValid = false;

            SelectionType selectionType;
            if (Enum.TryParse(input, true, out selectionType))
            {
                if (selectionType != SelectionType.NotSpecified)
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}