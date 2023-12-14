using Application.Features.UserFeatures.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.Validators;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("نام کاربر معتبر نمی باشد");
        RuleFor(c => c.Email).Must(EmailValidation).WithMessage("ایمیل کاربر معتبر نمی باشد");
        RuleFor(c => c.Password).NotEmpty().NotNull().WithMessage("رمز عبور کاربر معتبر نمی باشد");
    }

    private bool EmailValidation(string email)
    {
        string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

        if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, regex, RegexOptions.IgnoreCase))
            return false;

        return true;
    }
}
