using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Models.Requests;

namespace Youtube.Api.Validators
{
    public class NewCommentValidator : AbstractValidator<NewCommentRequest>
    {
        public NewCommentValidator()
        {
            RuleFor(x => x.PostingDate).NotEmpty().Must(date => DateTime.Compare(DateTime.Parse(date), DateTime.Now) <= 0);
            RuleFor(x => x.Text).NotEmpty().Length(3, 20);
            RuleFor(x => x.VideoId).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
