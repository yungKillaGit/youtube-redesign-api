using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Core.Interfaces.UseCases;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Dto;

namespace Youtube.Api.Core.UseCases
{
    public class SectionListUseCase : ISectionListUseCase
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionListUseCase(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public bool Handle(IOutputPort<IEnumerable<SectionDto>> outputPort)
        {
            outputPort.Handle(_sectionRepository.GetSections());
            return true;
        }
    }
}
