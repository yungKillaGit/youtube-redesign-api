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
    public class SubscriptionProcessingUseCase : ISubscriptionProcessingUseCase
    {
        private readonly IChannelSubscriberRepository _channelSubscriberRepository;
        private readonly IUserRepository _userRepository;
        private readonly IChannelRepository _channelRepository;

        public SubscriptionProcessingUseCase(IChannelSubscriberRepository channelSubscriberRepository, IUserRepository userRepository, IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
            _channelSubscriberRepository = channelSubscriberRepository;
            _userRepository = userRepository;
        }

        public bool Handle(SubscriptionProcessingRequest useCaseRequest, IOutputPort<SubscriptionProcessingResponse> outputPort)
        {
            if (_userRepository.FindById(useCaseRequest.UserId) == null)
            {
                outputPort.Handle(new SubscriptionProcessingResponse(new[] { new Error(404, "user not found") }));
                return false;
            }
            if (_channelRepository.FindById(useCaseRequest.ChannelId) == null)
            {
                outputPort.Handle(new SubscriptionProcessingResponse(new[] { new Error(404, "channel not found") }));
                return false;
            }
            if (_channelRepository.FindByUserId(useCaseRequest.UserId) != null)
            {
                outputPort.Handle(new SubscriptionProcessingResponse(new[] { new Error(422, "you cannot subscribe to yourself") }));
                return false;
            }
            int channelSubscriberId = _channelSubscriberRepository.HandleSubscription(useCaseRequest.UserId, useCaseRequest.ChannelId);
            outputPort.Handle(new SubscriptionProcessingResponse(channelSubscriberId));
            return true;
        }
    }
}
