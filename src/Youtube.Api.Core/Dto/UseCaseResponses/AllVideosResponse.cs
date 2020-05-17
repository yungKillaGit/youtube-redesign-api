using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class AllVideosResponse
    {
        public IEnumerable<VideoDto> Videos { get; }

        public AllVideosResponse(IEnumerable<VideoDto> videos)
        {
            Videos = videos;
        }
    }
}
