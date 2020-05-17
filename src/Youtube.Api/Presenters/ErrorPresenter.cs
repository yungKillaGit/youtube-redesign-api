using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Serialization;

namespace Youtube.Api.Presenters
{
    public class ErrorPresenter : IOutputPort<Error>
    {
        public JsonContentResult ContentResult { get; }

        public ErrorPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(Error response)
        {
            ContentResult.StatusCode = response.Code;
            ContentResult.Content = JsonSerializer.SerializeObject(response.Description);
        }
    }
}
