using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Models.Requests;

namespace Youtube.Api.Validators
{
    public class NewChannelValidator : AbstractValidator<NewChannelRequest>
    {
        public NewChannelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 20);            
            RuleFor(x => x.Description).MaximumLength(30).When(x => !String.IsNullOrEmpty(x.Description));
        }
    }
}
