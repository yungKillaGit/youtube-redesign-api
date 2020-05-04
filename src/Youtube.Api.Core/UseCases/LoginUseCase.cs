using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Core.Interfaces.Services;
using Youtube.Api.Core.Interfaces.UseCases;

namespace Youtube.Api.Core.UseCases
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;

        public LoginUseCase(IUserRepository userRepository, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }

        public bool Handle(LoginRequest useCaseRequest, IOutputPort<LoginResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(useCaseRequest.Email) && !string.IsNullOrEmpty(useCaseRequest.PasswordHash))
            {
                UserDto user = _userRepository.FindByEmail(useCaseRequest.Email);
                if (user != null)
                {
                    if (user.PasswordHash == useCaseRequest.PasswordHash)
                    {
                        Token token = _jwtFactory.GenerateEncodedToken(user.Id, user.Email);
                        outputPort.Handle(new LoginResponse(token));
                        return true;
                    }
                }
            }
            outputPort.Handle(new LoginResponse(new[] { new Error(422, "invalid username or password") }));
            return false;
        }
    }
}
