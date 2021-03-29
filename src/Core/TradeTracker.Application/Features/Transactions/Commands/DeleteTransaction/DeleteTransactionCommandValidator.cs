using FluentValidation;
using TradeTracker.Application.Features.Transactions.Shared.Validators;

namespace TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandValidator : AbstractValidator<DeleteTransactionCommand>
    {
        public DeleteTransactionCommandValidator()
        {
            RuleFor(t => t.AccessKey)
                .SetValidator(new AccessKeyValidator());
        }
    }
}