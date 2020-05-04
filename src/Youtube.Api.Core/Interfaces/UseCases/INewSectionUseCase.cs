using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseRequests;

namespace Youtube.Api.Core.Interfaces.UseCases
{
    public interface INewSectionUseCase : IUseCaseRequestHandler<NewSectionRequest, int>
    {
    }
}
