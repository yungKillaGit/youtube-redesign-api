using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseRequests
{
    public class NewSectionRequest : IUseCaseRequest<int>
    {
        public string Name { get; }

        public NewSectionRequest(string name)
        {
            Name = name;
        }
    }
}
