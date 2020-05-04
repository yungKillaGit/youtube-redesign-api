using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class LoginResponse : UseCaseResponseMessage
    {
        public Token Token { get; }
        public IEnumerable<Error> Errors { get; }

        public LoginResponse(Token token, bool success = true, string message = null) : base(success, message)
        {
            Token = token;
        }

        public LoginResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
