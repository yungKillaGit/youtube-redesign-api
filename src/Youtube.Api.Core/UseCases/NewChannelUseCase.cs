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

        public bool Handle(NewChannelRequest request, IOutputPort<NewChannelResponse> outputPort)
        {
            if (_userRepository.FindById(request.UserId) == null)
            {
                outputPort.Handle(new NewChannelResponse(new[] { new Error(404, "user not found") }));
                return false;
            }
            if (_channelRepository.FindByUserId(request.UserId) != null)
            {
                outputPort.Handle(new NewChannelResponse(new[] { new Error(422, "user already have channel") }));
                return false;
            }
            if (_channelRepository.FindByName(request.Name) != null)
            {
                outputPort.Handle(new NewChannelResponse(new[] { new Error(422, "channel name is busy") }));
                return false;
            }
            var channelInfo = new ChannelDto()
            {
                UserId = request.UserId,
                RegistrationDate = request.RegistrationDate,
                Description = request.Description,
                Name = request.Name,
            };
            int channelId = _channelRepository.Create(channelInfo);
            outputPort.Handle(new NewChannelResponse(channelId));
            return true;
        }
    }
}
