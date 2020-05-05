using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;

namespace Youtube.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IChannelSubscriberRepository
    {
        int Create(ChannelSubscriberDto subscriberInfo);
        UserDto FindChannelSubscriber(int userId);
        bool CheckIfUserAlreadyChannelSubscriber(int userId, int channelId);
    }
}
