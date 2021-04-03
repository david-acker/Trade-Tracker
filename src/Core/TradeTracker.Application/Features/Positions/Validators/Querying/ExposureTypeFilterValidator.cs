using FluentValidation;
using TradeTracker.Application.Common.Helpers;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Features.Positions.Querying.Validators
{
    public class ExposureTypeFilterValidator : AbstractValidator<string>
    {
        public ExposureTypeFilterValidator()
        {
            RuleFor(t => t)
                .Must(t => EnumHelper.IsNotDefault<ExposureType>(t))
                    .WithMessage($"ExposureType requires a valid type: {EnumHelper.Display<ExposureType>(1)}");
        }
    }
}