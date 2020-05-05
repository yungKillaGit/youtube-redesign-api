using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Infrastructure.Data.Entities;

namespace Youtube.Api.Infrastructure.Data.Mapping
{
    public class Comments : Profile
    {
        public Comments()
        {
            CreateMap<Comment, CommentDto>().ReverseMap();
        }
    }
}
