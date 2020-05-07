using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Dto.GatewayResponses.Repositories;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Core.Interfaces.Services;
using Youtube.Api.Core.Interfaces.UseCases;

namespace Youtube.Api.Core.UseCases
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {        
        private readonly IUserRepository _userRepository;
        private readonly IUploadedFileRepository _uploadedFileRepository;
        private readonly IUploadService _uploadService;
        private readonly IProfilePictureRepository _profilePictureRepository;

        public RegisterUserUseCase(
            IUserRepository userRepository,
            IUploadedFileRepository uploadedFileRepository,
            IUploadService uploadService,
            IProfilePictureRepository profilePictureRepository
        )
        {
            _userRepository = userRepository;
            _uploadedFileRepository = uploadedFileRepository;
            _uploadService = uploadService;
            _profilePictureRepository = profilePictureRepository;
        } 

        public async Task<bool> Handle(RegisterUserRequest request, IOutputPort<RegisterUserResponse> outputPort)
        {
            if (_userRepository.FindByEmail(request.Email) != null)
            {
                outputPort.Handle(new RegisterUserResponse(new[] { new Error(422, "user with this email is already exists") }));
                return false;
            }            
            var userInfo = new UserDto()
            {
                Name = request.Name,
                Email = request.Email,
                BirthDay = request.BirthDay,
                PasswordHash = request.PasswordHash,
                ProfilePictureId = null,
            };
            CreatedUserResponse response = _userRepository.Create(userInfo);
            if (request.Picture != null)
            {
                var uploadedPicture = await _uploadService.UploadFile(request.Picture, response.Id, request.WebRootPath);
                int pictureId = _uploadedFileRepository.Create(uploadedPicture);
                _userRepository.SetUserProfilePicture(pictureId, response.Id);
            }
            outputPort.Handle(new RegisterUserResponse(response.Id));
            return true;
        }
    }
}
