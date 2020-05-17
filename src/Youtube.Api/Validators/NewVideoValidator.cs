using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Models.Requests;

namespace Youtube.Api.Validators
{
    public class NewVideoValidator : AbstractValidator<NewVideoRequest>
    {
        public NewVideoValidator()
        {
            RuleFor(x => x.VideoFile).NotEmpty();
            RuleFor(x => x.VideoPreview).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().Length(3, 15);
            RuleFor(x => x.Description).MaximumLength(30).When(x => !String.IsNullOrEmpty(x.Description));
        }
    }
}
