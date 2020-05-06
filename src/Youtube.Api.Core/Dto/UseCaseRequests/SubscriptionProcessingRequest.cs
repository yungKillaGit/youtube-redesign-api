using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseRequests
{
    public class SubscriptionProcessingRequest : IUseCaseRequest<SubscriptionProcessingResponse>
    {
        public int ChannelId { get; }
        public int UserId { get; }

        public SubscriptionProcessingRequest(int channelId, int userId)
        {
            ChannelId = channelId;
            UserId = userId;
        }
    }
}
