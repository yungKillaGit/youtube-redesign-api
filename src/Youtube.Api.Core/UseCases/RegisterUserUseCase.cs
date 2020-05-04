using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Dto.GatewayResponses.Repositories;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Core.Interfaces.UseCases;

namespace Youtube.Api.Core.UseCases
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {        
        public IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        } 

        public bool Handle(RegisterUserRequest useCaseRequest, IOutputPort<RegisterUserResponse> outputPort)
        {
            var userInfo = new UserDto()
            {
                Name = useCaseRequest.Name,
                Email = useCaseRequest.Email,
                BirthDay = useCaseRequest.BirthDay,
                PasswordHash = useCaseRequest.PasswordHash,
                ProfilePictureId = useCaseRequest.ProfilePictureId,
            };
            CreatedUserResponse response = _userRepository.Create(userInfo);
            outputPort.Handle(new RegisterUserResponse(response.Id));
            return true;
        }
    }
}
