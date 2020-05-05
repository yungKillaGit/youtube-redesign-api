using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class NewSubscriberResponse : UseCaseResponseMessage
    {
        public int Id { get; }
        public IEnumerable<Error> Errors { get; }

        public NewSubscriberResponse(int id, bool success = true, string message = null) : base(success, message)
        {
            Id = id;
        }

        public NewSubscriberResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
