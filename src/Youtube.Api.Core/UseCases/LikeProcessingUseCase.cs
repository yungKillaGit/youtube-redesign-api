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
    public class LikeProcessingUseCase : ILikeProcessingUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IVideoRepository _videoRepository;

        public LikeProcessingUseCase(IUserRepository userRepository, IVideoRepository videoRepository)
        {
            _userRepository = userRepository;
            _videoRepository = videoRepository;
        }

        public bool Handle(LikeProcessingRequest request, IOutputPort<LikeProcessingResponse> outputPort)
        {
            if (_userRepository.FindById(request.UserId) == null)
            {
                outputPort.Handle(new LikeProcessingResponse(new[] { new Error(404, "user not found") }));
                return false;
            }
            if (_videoRepository.FindById(request.VideoId) == null)
            {
                outputPort.Handle(new LikeProcessingResponse(new[] { new Error(404, "video not found") }));
                return false;
            }
            _videoRepository.HandleLike(request.VideoId, request.UserId);
            outputPort.Handle(new LikeProcessingResponse());
            return true;
        }
    }
}
