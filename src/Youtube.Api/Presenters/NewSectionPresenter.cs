using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Serialization;

namespace Youtube.Api.Presenters
{
    public class NewSectionPresenter : IOutputPort<int>
    {
        public JsonContentResult ContentResult { get; }

        public NewSectionPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(int response)
        {
            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
