using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Serialization;

namespace Youtube.Api.Presenters
{
    public class SectionListPresenter : IOutputPort<IEnumerable<SectionDto>>
    {
        public JsonContentResult ContentResult { get; }

        public SectionListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(IEnumerable<SectionDto> response)
        {
            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
