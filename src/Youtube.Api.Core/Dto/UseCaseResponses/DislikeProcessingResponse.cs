using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class DislikeProcessingResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }

        public DislikeProcessingResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public DislikeProcessingResponse(bool success = true, string message = null) : base(success, message)
        {

        }
    }
}
