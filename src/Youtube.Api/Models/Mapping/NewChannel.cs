using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.UseCaseRequests;

namespace Youtube.Api.Models.Mapping
{
    public class NewChannel : Profile
    {
        public NewChannel()
        {
            CreateMap<Models.Requests.NewChannelRequest, NewChannelRequest>().ConstructUsing(x => new NewChannelRequest(
                x.UserId,
                DateTime.Parse(x.RegistrationDate),
                x.Description
            ));
        }
    }
}
