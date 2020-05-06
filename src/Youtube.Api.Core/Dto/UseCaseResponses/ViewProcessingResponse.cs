using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class ViewProcessingResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }

        public ViewProcessingResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ViewProcessingResponse(bool success = true, string message = null) : base(success, message)
        {

        }
    }
}
