using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Models.Requests;

namespace Youtube.Api.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Matches("^(?i)[а-яё]{3,15}$");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().NotEqual(x => x.Email).Length(6, 10);
            RuleFor(x => x.BirthDay).NotEmpty();
        }
    }
}
