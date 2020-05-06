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

        private ChannelSubscriber GetChannelSubscriber(int userId, int channelId)
        {            
            return _database.ChannelSubscribers.Where(x => x.UserId == userId && x.ChannelId == channelId).FirstOrDefault();
        }        

        public int HandleSubscription(int userId, int channelId)
        {
            ChannelSubscriber subscriber = GetChannelSubscriber(userId, channelId);
            int subscriberId = -1;
            if (subscriber == null)
            {
                subscriber = new ChannelSubscriber()
                {
                    ChannelId = channelId,
                    UserId = userId,
                };
                _database.ChannelSubscribers.Add(subscriber);
                _database.SaveChanges();
                subscriberId = subscriber.Id;
            }
            else
            {
                subscriberId = subscriber.Id;
                _database.ChannelSubscribers.Remove(subscriber);
                _database.SaveChanges();
            }

            return subscriberId;
        }
    }
}
