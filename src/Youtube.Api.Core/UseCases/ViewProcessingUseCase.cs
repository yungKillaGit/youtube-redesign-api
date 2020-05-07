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

        public bool Handle(ViewProcessingRequest request, IOutputPort<ViewProcessingResponse> outputPort)
        {
            if (request.UserId != null)
            {
                if (_userRepository.FindById((int)(request.UserId)) == null)
                {
                    outputPort.Handle(new ViewProcessingResponse(new[] { new Error(404, "user not found") }));
                    return false;
                }
            }            
            if (_videoRepository.FindById(request.VideoId) == null)
            {
                outputPort.Handle(new ViewProcessingResponse(new[] { new Error(404, "video not found") }));
                return false;
            }
            _videoRepository.HandleView(request.VideoId, request.UserId);
            outputPort.Handle(new ViewProcessingResponse());
            return true;
        }
    }
}
