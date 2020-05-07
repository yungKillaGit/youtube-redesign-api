using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseRequests
{
    public class RegisterUserRequest : IUseCaseRequest<RegisterUserResponse>
    {        
        public string Name { get; }
        public string Email { get; }
        public DateTime BirthDay { get; }
        public string PasswordHash { get; }
        public IFormFile Picture { get; }
        public string WebRootPath { get; }

        public RegisterUserRequest(string name, string email, DateTime birthDay, string passwordHash, IFormFile picture, string webRootPath)
        {
            Name = name;
            Email = email;
            BirthDay = birthDay;
            PasswordHash = passwordHash;
            Picture = picture;
            WebRootPath = webRootPath;
        }
    }
}
