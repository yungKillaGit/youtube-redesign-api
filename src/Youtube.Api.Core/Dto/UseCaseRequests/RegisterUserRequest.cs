using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseRequests
{
    public class RegisterUserRequest : IUseCaseRequest<RegisterUserResponse>
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string PasswordHash { get; set; }
        public int? ProfilePictureId { get; set; }
    }
}
