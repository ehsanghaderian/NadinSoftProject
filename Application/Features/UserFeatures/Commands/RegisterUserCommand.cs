﻿using Application.Extensions;
using Application.Features.ProductFeatures.Commands.Validators;
using Application.Share;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class RegisterUserCommand : CommandRequestBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public override void Validate()
        {
            new RegisterUserCommandValidator().Validate(this).RaiseExceptionIfRequired();
        }
    }
}
