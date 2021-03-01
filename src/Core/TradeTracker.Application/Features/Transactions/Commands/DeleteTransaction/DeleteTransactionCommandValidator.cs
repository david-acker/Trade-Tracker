using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandValidator : AbstractValidator<DeleteTransactionCommand>
    {
        public DeleteTransactionCommandValidator()
        {
            RuleFor(t => t.AccessKey).SetValidator(new AccessKeyValidator());
            
            RuleFor(t => t.TransactionId)
                .NotNull()
                .NotEmpty()
                    .WithMessage("A valid {PropertyName} must be provided.");
        }
    }
}