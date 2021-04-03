using FluentValidation;
using TradeTracker.Application.Common.Helpers;

namespace TradeTracker.Application.Features.Transactions.Validators.Querying
{
    public class TransactionOrderByValidator : AbstractValidator<string>
    {
        public TransactionOrderByValidator()
        {
            RuleFor(s => s)
                .Cascade(CascadeMode.Stop)
                .Must(s => StringHelper.containsNumberOfElementsAfterSplit(s, 2, ' '))
                    .WithMessage("OrderBy must include both a Field and a SortType.")
                .SetValidator(new TransactionOrderByComponentsValidator());
        }
    }
}
