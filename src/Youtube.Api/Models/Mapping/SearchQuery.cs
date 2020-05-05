using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.UseCaseRequests;

namespace Youtube.Api.Models.Mapping
{
    public class SearchQuery : Profile
    {
        public SearchQuery()
        {            
            CreateMap<Models.Requests.SearchRequest, SearchRequest>().ConstructUsing(x => new SearchRequest(
                Regex.Replace(x.SearchQuery, @"\s+", " ").ToLower()
            ));
        }
    }
}
