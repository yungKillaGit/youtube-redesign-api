using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class SearchResponse : UseCaseResponseMessage
    {
        public IEnumerable<VideoDto> Videos { get; }
        public ChannelDto Channel { get; set; }
        
        public SearchResponse(IEnumerable<VideoDto> videos, ChannelDto channel, bool success = true, string message = null)
        {
            Videos = videos;
            Channel = channel;
        }
    }
}
