using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class RegisterUserResponse : UseCaseResponseMessage
    {
        public UserDto User { get; }
        public IEnumerable<Error> Errors { get; }

        public RegisterUserResponse(UserDto user, bool success = true, string message = null) : base(success, message)
        {
            User = user;
        }

        public RegisterUserResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
