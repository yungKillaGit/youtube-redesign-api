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
    public class ViewProcessingUseCase : IViewProcessingUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IVideoRepository _videoRepository;

        public ViewProcessingUseCase(IUserRepository userRepository, IVideoRepository videoRepository)
        {
            _userRepository = userRepository;
            _videoRepository = videoRepository;
        }

        public bool Handle(ViewProcessingRequest useCaseRequest, IOutputPort<ViewProcessingResponse> outputPort)
        {
            if (useCaseRequest.UserId != null)
            {
                if (_userRepository.FindById((int)(useCaseRequest.UserId)) == null)
                {
                    outputPort.Handle(new ViewProcessingResponse(new[] { new Error(404, "user not found") }));
                    return false;
                }
            }            
            if (_videoRepository.FindById(useCaseRequest.VideoId) == null)
            {
                outputPort.Handle(new ViewProcessingResponse(new[] { new Error(404, "video not found") }));
                return false;
            }
            _videoRepository.HandleView(useCaseRequest.VideoId, useCaseRequest.UserId);
            outputPort.Handle(new ViewProcessingResponse());
            return true;
        }
    }
}
