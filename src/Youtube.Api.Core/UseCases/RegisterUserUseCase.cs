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
        private readonly IImageRepository _imageRepository;

        public RegisterUserUseCase(
            IUserRepository userRepository,
            IUploadedFileRepository uploadedFileRepository,
            IUploadService uploadService,
            IImageRepository imageRepository
        )
        {
            _userRepository = userRepository;
            _uploadedFileRepository = uploadedFileRepository;
            _uploadService = uploadService;
            _imageRepository = imageRepository;
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
            };            
            UserDto createdUser = _userRepository.Create(userInfo);
            if (request.Picture != null)
            {
                var uploadedPicture = await _uploadService.UploadFile(request.Picture, request.WebRootPath);
                UploadedFileDto uploadedFile = _uploadedFileRepository.Create(uploadedPicture);
                uploadedPicture.Id = uploadedFile.Id;

                ImageDto createdPicture = _imageRepository.Create(new ImageDto() { UserId = createdUser.Id }, request.WebRootPath, uploadedPicture);
                createdUser = _userRepository.SetUserProfilePicture(createdPicture.Id, createdUser.Id);
            }
            outputPort.Handle(new RegisterUserResponse(createdUser));
            return true;
        }
    }
}
