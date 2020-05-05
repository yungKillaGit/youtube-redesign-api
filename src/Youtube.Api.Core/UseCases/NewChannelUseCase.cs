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
    public class NewChannelUseCase : INewChannelUseCase
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IUserRepository _userRepository;

        public NewChannelUseCase(IChannelRepository channelRepository, IUserRepository userRepository)
        {
            _channelRepository = channelRepository;
            _userRepository = userRepository;
        }

        public bool Handle(NewChannelRequest useCaseRequest, IOutputPort<NewChannelResponse> outputPort)
        {
            if (_userRepository.FindById(useCaseRequest.UserId) == null)
            {
                outputPort.Handle(new NewChannelResponse(new[] { new Error(404, "user not found") }));
                return false;
            }
            if (_channelRepository.FindByUserId(useCaseRequest.UserId) != null)
            {
                outputPort.Handle(new NewChannelResponse(new[] { new Error(422, "user already have channel") }));
                return false;
            }
            var channelInfo = new ChannelDto()
            {
                UserId = useCaseRequest.UserId,
                RegistrationDate = useCaseRequest.RegistrationDate,
                Description = useCaseRequest.Description,
                Name = useCaseRequest.Name,
            };
            int channelId = _channelRepository.Create(channelInfo);
            outputPort.Handle(new NewChannelResponse(channelId));
            return true;
        }
    }
}
