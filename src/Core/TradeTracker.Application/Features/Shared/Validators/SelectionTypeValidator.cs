using System;
using FluentValidation;
using TradeTracker.Application.Enums;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class SelectionTypeValidator : AbstractValidator<SelectionType>
    {
        public SelectionTypeValidator()
        {
            RuleFor(s => s)
                .Must(s => s != SelectionType.NotSpecified)
                    .WithMessage("Must include a valid SelectionType: include, exclude");
        }
    }
}
