using System;
using System.Collections.Generic;
using FluentValidation;
using TradeTracker.Application.Enums;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class SelectionValidator : AbstractValidator<List<string>>
    {
        public SelectionValidator()
        {
            RuleForEach(s => s)
                .SetValidator(new SymbolStringValidator());
        }
    }
}
