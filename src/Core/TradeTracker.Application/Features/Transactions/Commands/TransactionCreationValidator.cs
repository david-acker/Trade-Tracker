using FluentValidation;
using System;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Features.Transactions.Commands
{
    public class TransactionCreationValidator : AbstractValidator<TransactionForCreationDto>
    {
        public TransactionCreationValidator()
        {
            RuleFor(t => t.AccessKey).SetValidator(new AccessKeyValidator());

            RuleFor(t => t.DateTime)
                .NotNull()
                .NotEmpty()
                    .WithMessage("{PropertyName}s must not be blank.")
                .LessThanOrEqualTo(DateTime.Now)
                    .WithMessage("{PropertyName}s must have already occurred.");

            RuleFor(t => t.Symbol)
                .NotNull()
                .NotEmpty()
                    .WithMessage("{PropertyName}s must not be blank.")
                .MaximumLength(12)
                    .WithMessage("{PropertyName}s must not exceed 12 characters.");

            RuleFor(t => t.TransactionType)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Every transaction must specify a {PropertyName}.")
                .IsEnumName(typeof(TransactionType), caseSensitive: false)
                    .WithMessage("Every transaction must have a valid {PropertyName}.");

            RuleFor(t => t.Quantity)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Every transaction must specify a {PropertyName}.")
                .GreaterThan(0)
                    .WithMessage("Every {PropertyName} must be greater than zero.");

            RuleFor(t => t.Notional)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Every transaction must specify a {PropertyName}.")
                .GreaterThan(0)
                    .WithMessage("Every {PropertyName} must be greater than zero.");

            When(t => (t.TradePrice != null), () => 
                {
                    RuleFor(t => t.TradePrice)
                        .GreaterThan(0)
                            .WithMessage("Every {PropertyName} must be greater than zero.");
                });

            RuleFor(t => t.Tags).SetValidator(new TagsValidator());
        }
    }
}