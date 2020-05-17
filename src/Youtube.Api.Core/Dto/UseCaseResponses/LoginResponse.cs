using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class LoginResponse : UseCaseResponseMessage
    {
        public Token Token { get; }
        public IEnumerable<Error> Errors { get; }
        public UserDto User { get; }

        public LoginResponse(UserDto user, Token token, bool success = true, string message = null) : base(success, message)
        {
            Token = token;
            User = user;
        }

        public LoginResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
