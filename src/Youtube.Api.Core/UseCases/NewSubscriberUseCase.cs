using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Core.Interfaces.UseCases;

namespace Youtube.Api.Core.UseCases
{
    public class NewSubscriberUseCase : INewSubscriberUseCase
    {
        private readonly IChannelSubscriberRepository _channelSubscriberRepository;
        private readonly IUserRepository _userRepository;
        private readonly IChannelRepository _channelRepository;

        public NewSubscriberUseCase(IChannelSubscriberRepository channelSubscriberRepository, IUserRepository userRepository, IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
            _channelSubscriberRepository = channelSubscriberRepository;
            _userRepository = userRepository;
        }

        public bool Handle(NewSubscriberRequest useCaseRequest, IOutputPort<NewSubscriberResponse> outputPort)
        {
            if (_userRepository.FindById(useCaseRequest.UserId) == null)
            {
                outputPort.Handle(new NewSubscriberResponse(new[] { new Error(404, "user not found") }));
                return false;
            }
            if (_channelRepository.FindById(useCaseRequest.ChannelId) == null)
            {
                outputPort.Handle(new NewSubscriberResponse(new[] { new Error(404, "channel not found") }));
                return false;
            }
            if (_channelSubscriberRepository.CheckIfUserAlreadyChannelSubscriber(useCaseRequest.UserId, useCaseRequest.ChannelId))
            {
                outputPort.Handle(new NewSubscriberResponse(new[] { new Error(422, "user is already subscribed to this channel") }));
                return false;
            }
            var channelSubscriberInfo = new ChannelSubscriberDto()
            {
                ChannelId = useCaseRequest.ChannelId,
                UserId = useCaseRequest.UserId,
            };
            int channelSubscriberId = _channelSubscriberRepository.Create(channelSubscriberInfo);
            outputPort.Handle(new NewSubscriberResponse(channelSubscriberId));
            return true;
        }
    }
}
