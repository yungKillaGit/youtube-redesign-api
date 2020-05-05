using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class NewCommentResponse : UseCaseResponseMessage
    {
        public int? Id { get; set; }
        public IEnumerable<Error> Errors { get; set; }

        public NewCommentResponse(int id, bool success = true, string message = null) : base(success, message)
        {
            Id = id;
        }

        public NewCommentResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
