using System;
using System.Linq;
using FluentValidation;

namespace TradeTracker.Application.Features.Positions.Validators.Querying
{
    public class ExposureTypeFilterValidator : AbstractValidator<string>
    {
        public ExposureTypeFilterValidator()
        {
            RuleFor(t => t)
                .Must(t => IsValidExposureTypeForFiltering(t))
                    .WithMessage("Cannot filter with an invalid Exposuretype.");
        }
        
        private bool IsValidExposureTypeForFiltering(string input)
        {   
            var validExposureTypes = new string[]
            { 
                "long", 
                "short" 
            };

            var cleanedInput = input
                .Trim()
                .ToLower();

            bool isValid = true;

            if (!String.IsNullOrWhiteSpace(cleanedInput))
            {
                isValid = validExposureTypes.Contains(cleanedInput);
            }

            return isValid;
        }
    }
}