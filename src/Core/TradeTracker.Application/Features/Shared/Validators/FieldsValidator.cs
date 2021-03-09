using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class FieldsValidator : AbstractValidator<List<string>>
    {
        public FieldsValidator()
        {
            When(f => f != null, () =>
            {
                RuleForEach(f => f)
                    .SetValidator(new FieldValidator());
            });
        }
    }
}
