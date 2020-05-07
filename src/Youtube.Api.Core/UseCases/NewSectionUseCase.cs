using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Core.Interfaces.UseCases;

namespace Youtube.Api.Core.UseCases
{
    public class NewSectionUseCase : INewSectionUseCase
    {
        private readonly ISectionRepository _sectionRepository;

        public NewSectionUseCase(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public bool Handle(NewSectionRequest request, IOutputPort<int> outputPort)
        {
            int newSectionId = _sectionRepository.Create(new SectionDto() { Name = request.Name });
            outputPort.Handle(newSectionId);

            return true;
        }
    }
}
