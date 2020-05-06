using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;

namespace Youtube.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IChannelSubscriberRepository
    {
        int HandleSubscription(int userId, int channelId);
    }
}
