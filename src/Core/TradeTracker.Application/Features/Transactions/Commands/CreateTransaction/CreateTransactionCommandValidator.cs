using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {
            RuleFor(t => t).SetValidator(new TransactionCreationValidator());
        }
    }
}