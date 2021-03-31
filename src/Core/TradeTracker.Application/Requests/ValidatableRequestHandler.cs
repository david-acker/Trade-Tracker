using FluentValidation;
using System;
using System.Threading.Tasks;

namespace TradeTracker.Application.Requests
{
    public class ValidatableRequestHandler<TRequest>
    {
        protected async Task ValidateRequest(TRequest request) 
        {
            Type requestType = typeof(TRequest);

            var validator = 
                (AbstractValidator<TRequest>)Activator.CreateInstance(
                    Type.GetType($"{requestType.ToString()}Validator")
                );

            var validationResult = await validator.ValidateAsync(request);
            
            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
        }
    }
}