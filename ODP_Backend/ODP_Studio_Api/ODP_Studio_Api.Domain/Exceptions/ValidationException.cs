using System;
using FluentValidation.Results;

namespace ODP_Studio_Api.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<string> Errors { get; }

        public ValidationException(string message, IEnumerable<string> errors = null) : base(message)
        {
            Errors = errors ?? Array.Empty<string>();
        }
        public ValidationException(ValidationResult validationResult)
        {
            var errorMessages = validationResult.Errors
                         .Select(error => error.ErrorMessage);

            // Create your custom exception with a message and error messages array
             new ValidationException("Validation failed", errorMessages);
        }

    }
}
