using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class NewVideoResponse : UseCaseResponseMessage
    {
        public VideoDto Video { get; }
        public IEnumerable<Error> Errors { get; }

        public NewVideoResponse(VideoDto video, bool success = true, string message = null) : base(success, message)
        {
            Video = video;
        }

        public NewVideoResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
