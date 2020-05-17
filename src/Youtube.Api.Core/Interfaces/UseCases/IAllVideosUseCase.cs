using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseResponses;

namespace Youtube.Api.Core.Interfaces.UseCases
{
    public interface IAllVideosUseCase : IUseCaseRequestHandler<AllVideosResponse>
    {
    }
}
