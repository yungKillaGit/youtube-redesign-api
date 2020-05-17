using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Serialization;

namespace Youtube.Api.Presenters
{
    public class UploadFilePresenter : IOutputPort<UploadFileResponse>
    {
        public JsonContentResult ContentResult { get; }

        public UploadFilePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(UploadFileResponse response)
        {
            ContentResult.StatusCode = response.Success ? 200 : response.Error.Code;
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
