using System.Collections.Generic;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class TagsValidator : AbstractValidator<List<string>>
    {
        public TagsValidator()
        {
            RuleFor(t => t)
                .Must(t => t.Count <= 10)
                    .WithMessage("Tags must contain between 0 and 10 tags.");

            RuleForEach(t => t)
                .SetValidator(new TagValidator());
        }
    }
}