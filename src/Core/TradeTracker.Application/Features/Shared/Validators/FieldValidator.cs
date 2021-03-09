using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class FieldValidator : AbstractValidator<string>
    {
        static string[] ValidFieldNames = new string[]
        {
            "TransactionId",
            "DateTime",
            "Symbol",
            "Type",
            "Quantity",
            "Notional",
            "TradePrice"
        };

        public FieldValidator()
        {
            RuleFor(f => f)
                .Must(IsValidField)
                    .WithMessage(f => String.Format($"{f} is not a valid field name."));
        }

        private bool IsValidField(string fieldName)
        {
            return FieldValidator.ValidFieldNames.Contains(fieldName);
        }
    }
}
