using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Extensions
{
    public static class ValidationResultExtension
    {
        public static void RaiseExceptionIfRequired(this ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors.First().ErrorMessage);
        }
    }
}
