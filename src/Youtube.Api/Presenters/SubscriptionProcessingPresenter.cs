using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Serialization;

namespace Youtube.Api.Presenters
{
    public class SubscriptionProcessingPresenter : IOutputPort<SubscriptionProcessingResponse>
    {
        public JsonContentResult ContentResult { get; }

        public SubscriptionProcessingPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(SubscriptionProcessingResponse response)
        {
            ContentResult.StatusCode = response.Success ? 200 : response.Errors.First().Code;
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
