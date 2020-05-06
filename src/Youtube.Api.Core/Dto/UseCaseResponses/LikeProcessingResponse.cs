using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class LikeProcessingResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }

        public LikeProcessingResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public LikeProcessingResponse(bool success = true, string message = null) : base(success, message)
        {

        }
    }
}
