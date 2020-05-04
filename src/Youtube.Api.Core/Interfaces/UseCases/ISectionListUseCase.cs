using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;

namespace Youtube.Api.Core.Interfaces.UseCases
{
    public interface ISectionListUseCase : IUseCaseRequestHandler<IEnumerable<SectionDto>>
    {
    }
}
