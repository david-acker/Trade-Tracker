using System;
using System.Threading.Tasks;
using FluentValidation;

namespace TradeTracker.Application.Common.Behaviors
{
    public class ValidatableRequestBehavior<TRequest>
    {
        protected async Task ValidateRequest(TRequest request) 
        {
            Type requestType = typeof(TRequest);

            var validator = (AbstractValidator<TRequest>)Activator
                .CreateInstance(
                    Type.GetType($"{requestType.ToString()}Validator"));

            var validationResult = await validator.ValidateAsync(request);
            
            if (validationResult.Errors.Count > 0)
            {
                throw new Common.Exceptions.ValidationException(validationResult);
            }
        }
    }
}