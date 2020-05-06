using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;

namespace Youtube.Api.Core.Dto.GatewayResponses.Repositories
{
    public class SectionVideosResponse
    {
        public int SectionId { get; }
        public IEnumerable<VideoDto> Videos { get; }

        public SectionVideosResponse(int sectionId, IEnumerable<VideoDto> videos)
        {
            SectionId = sectionId;
            Videos = videos;
        }
    }
}
