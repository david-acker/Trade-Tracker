using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using TradeTracker.Application.Enums;

namespace TradeTracker.Application.Features.Positions.Validators.Querying
{
    public class PositionOrderComponentsValidator : AbstractValidator<string>
    {
        readonly string[] PositionOrderByFields = new string[]
        {
            "Symbol",
            "Quantity"
        };

        public PositionOrderComponentsValidator()
        {
            RuleForEach(s => extractOrderByFieldComponent(s))
                .Cascade(CascadeMode.Stop)
                .Must(q => PositionOrderByFields.Contains(q))
                    .WithMessage($"OrderByField requires a valid field name: {String.Join(", ", PositionOrderByFields)}.");
        
            RuleFor(s => extractSortOrderComponent(s))
                .Cascade(CascadeMode.Stop)
                .IsEnumName(typeof(SortOrderType), caseSensitive: false)
                    .WithMessage("A valid SortOrder is required: ascending, descending.")
                .Must(t => IsSortOrderSpecified(t))
                    .WithMessage("SortOrder cannot be left unspecified.");
        }

        private List<string> extractOrderByFieldComponent(string input)
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

        private string extractSortOrderComponent(string input)
        {
            var cleanedInput = input.Trim();

            return cleanedInput
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]
                .Trim();
        }

        private bool IsSortOrderSpecified(string input)
        {   
            var isValid = false;

            SortOrderType sortOrderType;
            if (Enum.TryParse(input, true, out sortOrderType))
            {
                if (sortOrderType != SortOrderType.NotSpecified)
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}
