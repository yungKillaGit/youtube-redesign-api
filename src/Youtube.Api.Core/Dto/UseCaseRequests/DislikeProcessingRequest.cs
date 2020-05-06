using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseRequests
{
    public class DislikeProcessingRequest : IUseCaseRequest<DislikeProcessingResponse>
    {
        public int UserId { get; }
        public int VideoId { get; }

        public DislikeProcessingRequest(int userId, int videoId)
        {
            UserId = userId;
            VideoId = videoId;
        }
    }
}
