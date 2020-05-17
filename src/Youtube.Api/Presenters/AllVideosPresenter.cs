using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Serialization;

namespace Youtube.Api.Presenters
{
    public class AllVideosPresenter : IOutputPort<AllVideosResponse>
    {
        public JsonContentResult ContentResult;

        public AllVideosPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(AllVideosResponse response)
        {
            ContentResult.StatusCode = 200;
            ContentResult.Content = JsonSerializer.SerializeObject(response.Videos);
        }
    }
}
