using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Serialization;

namespace Youtube.Api.Presenters
{
    public class SearchPresenter : IOutputPort<SearchResponse>
    {
        public JsonContentResult ContentResult { get; }

        public SearchPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(SearchResponse response)
        {
            ContentResult.StatusCode = 200;
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
