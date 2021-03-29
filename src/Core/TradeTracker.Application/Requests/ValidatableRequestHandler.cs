using FluentValidation;
using System;
using System.Threading.Tasks;

namespace TradeTracker.Application.Requests.ValidatedRequestHandler
{
    public class ValidatableRequestHandler<TRequest, TValidator> where TValidator : AbstractValidator<TRequest>
    {
        protected async Task ValidateRequest(TRequest request) 
        {
            AbstractValidator<TRequest> validator = Activator.CreateInstance<TValidator>();

            var validationResult = await validator.ValidateAsync(request);
            
            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
        }
    }
}