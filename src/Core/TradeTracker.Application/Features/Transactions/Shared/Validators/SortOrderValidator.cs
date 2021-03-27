using System;
using FluentValidation;
using TradeTracker.Application.Enums;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class SortOrderValidator : AbstractValidator<SortOrder>
    {
        public SortOrderValidator()
        {
            RuleFor(s => s)
                .Must(s => s != SortOrder.NotSpecified)
                    .WithMessage("If provided, SortOrder must be a valid: asc, desc");
        }
    }
}
