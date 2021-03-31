using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace TradeTracker.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }

        public ValidationException(string message)
        {
            ValidationErrors = new List<string>();

            ValidationErrors.Add(message);
        }

        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}