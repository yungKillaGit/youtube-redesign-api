using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.UseCaseRequests;

namespace Youtube.Api.Models.Mapping
{
    public class NewSubscriber : Profile
    {
        public NewSubscriber()
        {
            CreateMap<Models.Requests.NewSubscriberRequest, NewSubscriberRequest>();
        }
    }
}
