using System;
using System.Linq;
using FluentValidation;

namespace TradeTracker.Application.Features.Positions.Validators
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

            return validExposureTypes.Contains(cleanedInput);
        }
    }
}