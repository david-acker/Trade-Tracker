using FluentValidation;
using TradeTracker.Application.Features.Transactions.Shared.Validators;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection
{
    public class CreateTransactionCollectionCommandValidator : AbstractValidator<CreateTransactionCollectionCommand>
    {
        public CreateTransactionCollectionCommandValidator()
        {
            RuleForEach(t => t.Transactions).SetValidator(new TransactionForCreationValidator());
        }
    }
}
