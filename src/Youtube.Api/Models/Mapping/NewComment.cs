using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.UseCaseRequests;

namespace Youtube.Api.Models.Mapping
{
    public class NewComment : Profile
    {
        public NewComment()
        {
            CreateMap<Models.Requests.NewCommentRequest, NewCommentRequest>().ConstructUsing(x => new NewCommentRequest(
                x.UserId,
                DateTime.Parse(x.PostingDate),
                x.Text,
                x.VideoId
            ));
        }
    }
}
