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
    public class SectionVideosUseCase : ISectionVideosUseCase
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IUserRepository _userRepository;

        public SectionVideosUseCase(ISectionRepository sectionRepository, IUserRepository userRepository)
        {
            _sectionRepository = sectionRepository;
            _userRepository = userRepository;
        }

        public bool Handle(SectionVideosRequest useCaseRequest, IOutputPort<SectionVideosResponse> outputPort)
        {
            if (_userRepository.FindById(useCaseRequest.UserId) == null)
            {
                outputPort.Handle(new SectionVideosResponse(new[] { new Error(404, "user not found") }));
                return false;
            }
            var response = _sectionRepository.GetSectionVideos(useCaseRequest.UserId, useCaseRequest.SectionName);
            outputPort.Handle(new SectionVideosResponse(response.SectionId, response.Videos));
            return true;
        }
    }
}
