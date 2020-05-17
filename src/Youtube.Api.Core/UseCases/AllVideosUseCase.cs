using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Core.Interfaces.UseCases;

namespace Youtube.Api.Core.UseCases
{
    public class AllVideosUseCase : IAllVideosUseCase
    {
        private readonly IVideoRepository _videoRepository;

        public AllVideosUseCase(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public bool Handle(IOutputPort<AllVideosResponse> outputPort)
        {
            outputPort.Handle(new AllVideosResponse(_videoRepository.GetAllVideos()));
            return true;
        }
    }
}
