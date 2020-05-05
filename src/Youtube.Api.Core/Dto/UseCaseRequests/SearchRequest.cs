using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseRequests
{
    public class SearchRequest : IUseCaseRequest<SearchResponse>
    {
        public string SearchQuery { get; }

        public SearchRequest(string searchQuery)
        {
            SearchQuery = searchQuery;
        }
    }
}
