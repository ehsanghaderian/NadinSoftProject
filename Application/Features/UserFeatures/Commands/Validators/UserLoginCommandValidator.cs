using Application.Features.UserFeatures.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.Validators
{
    public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
    {
        public UserLoginCommandValidator()
        {
            RuleFor(c => c.UserName).NotEmpty().NotNull().WithMessage("نام کاربری معتبر نمی باشد");
            RuleFor(c => c.Password).NotEmpty().NotNull().WithMessage("رمز عبور کاربر معتبر نمی باشد");
        }
    }
}
