using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Infrastructure.Data.Entities;

namespace Youtube.Api.Infrastructure.Data.EntityFramework.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly IMapper _mapper;
        private readonly YoutubeContext _database;

        public ChannelRepository(IMapper mapper, YoutubeContext database)
        {
            _mapper = mapper;
            _database = database;
        }

        public int Create(ChannelDto channelInfo)
        {
            var channel = _mapper.Map<Channel>(channelInfo);
            _database.Channels.Add(channel);
            _database.SaveChanges();

            return channel.Id;
        }

        public ChannelDto FindByUserId(int userId)
        {
            return _mapper.Map<ChannelDto>(_database.Channels.Where(x => x.UserId == userId).FirstOrDefault());
        }
    }
}
