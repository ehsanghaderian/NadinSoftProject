using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.Validators
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(c => c.ManufacturerEmail).Must(EmailValidation).WithMessage("ایمیل سازنده محصول معتبر نمی باشد");
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("نام محصول معتبر نمی باشد");
            RuleFor(c => c.ProduceDate).NotEqual(DateTime.MinValue).NotEqual(DateTime.MaxValue).WithMessage("تاریخ تولید محصول معتبر نمی باشد");
        }

        private bool EmailValidation(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, regex, RegexOptions.IgnoreCase))
                return false;

            return true;
        }
    }
}
