using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Core.Interfaces.UseCases;

namespace Youtube.Api.Core.UseCases
{
    public class DislikeProcessingUseCase : IDislikeProcessingUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IVideoRepository _videoRepository;

        public DislikeProcessingUseCase(IUserRepository userRepository, IVideoRepository videoRepository)
        {
            _userRepository = userRepository;
            _videoRepository = videoRepository;
        }

        public bool Handle(DislikeProcessingRequest useCaseRequest, IOutputPort<DislikeProcessingResponse> outputPort)
        {
            if (_userRepository.FindById(useCaseRequest.UserId) == null)
            {
                outputPort.Handle(new DislikeProcessingResponse(new[] { new Error(404, "user not found") }));
                return false;
            }
            if (_videoRepository.FindById(useCaseRequest.VideoId) == null)
            {
                outputPort.Handle(new DislikeProcessingResponse(new[] { new Error(404, "video not found") }));
                return false;
            }
            _videoRepository.HandleDislike(useCaseRequest.VideoId, useCaseRequest.UserId);
            outputPort.Handle(new DislikeProcessingResponse());
            return true;
        }
    }
}
