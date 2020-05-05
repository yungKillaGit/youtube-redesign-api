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
    public class ChannelSubscriberRepository : IChannelSubscriberRepository
    {
        private readonly IMapper _mapper;
        private readonly YoutubeContext _database;

        public ChannelSubscriberRepository(IMapper mapper, YoutubeContext database)
        {
            _mapper = mapper;
            _database = database;
        }

        public bool CheckIfUserAlreadyChannelSubscriber(int userId, int channelId)
        {
            ChannelSubscriber channelSubscriber = _database.ChannelSubscribers.Where(x => x.UserId == userId && x.ChannelId == channelId).FirstOrDefault();
            return channelSubscriber != null;
        }

        public int Create(ChannelSubscriberDto subscriberInfo)
        {
            var channelSubscriber = _mapper.Map<ChannelSubscriber>(subscriberInfo);
            _database.ChannelSubscribers.Add(channelSubscriber);
            _database.SaveChanges();

            return channelSubscriber.Id;
        }

        public UserDto FindChannelSubscriber(int userId)
        {
            User user = _database.ChannelSubscribers.Where(x => x.UserId == userId).Select(x => x.User).FirstOrDefault();
            return _mapper.Map<UserDto>(user);
        }
    }
}
