using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseRequests
{
    public class ViewProcessingRequest : IUseCaseRequest<ViewProcessingResponse>
    {
        public int? UserId { get; }
        public int VideoId { get; }

        public ViewProcessingRequest(int? userId, int videoId)
        {
            UserId = userId;
            VideoId = videoId;
        }
    }
}
