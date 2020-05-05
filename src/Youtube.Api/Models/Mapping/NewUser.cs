using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Infrastructure.Auth;

namespace Youtube.Api.Models.Mapping
{
    public class NewUser : Profile
    {
        public NewUser()
        {
            CreateMap<Models.Requests.RegisterUserRequest, RegisterUserRequest>().ConstructUsing(x => new RegisterUserRequest()
            {
                BirthDay = DateTime.Parse(x.BirthDay),
                Email = x.Email,
                Name = x.Name,
                PasswordHash = Cipher.Encrypt(x.Password),
                ProfilePictureId = x.ProfilePictureId
            });
        }
    }
}
