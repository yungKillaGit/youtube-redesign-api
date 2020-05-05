using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;

namespace Youtube.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IChannelRepository
    {
        int Create(ChannelDto channelInfo);
        ChannelDto FindByUserId(int userId);
        ChannelDto FindById(int id);
        ChannelDto FindByName(string name);
    }
}
