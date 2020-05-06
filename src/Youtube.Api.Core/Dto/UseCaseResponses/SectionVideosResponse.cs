using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class SectionVideosResponse : UseCaseResponseMessage
    {
        public int SectionId { get; }
        public IEnumerable<VideoDto> Videos { get; }
        public IEnumerable<Error> Errors { get; }

        public SectionVideosResponse(int sectionId, IEnumerable<VideoDto> videos, bool success = true, string message = null) : base(success, message)
        {
            SectionId = sectionId;
            Videos = videos;
        }

        public SectionVideosResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
