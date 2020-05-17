using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Serialization;

namespace Youtube.Api.Presenters
{
    public class ImagePresenter
    {
        public JsonContentResult ContentResult { get; }

        public ImagePresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(string image64)
        {
            ContentResult.StatusCode = 200;
            ContentResult.Content = JsonSerializer.SerializeObject(image64);
        }
    }
}
