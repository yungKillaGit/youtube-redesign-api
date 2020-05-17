using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    public class NewVideoUseCase : INewVideoUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUploadService _uploadService;
        private readonly IVideoRepository _videoRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IUploadedFileRepository _uploadedFileRepository;
        private readonly IChannelRepository _channelRepository;

        public NewVideoUseCase(
            IUserRepository userRepository,
            IUploadService uploadService,
            IVideoRepository videoRepository,
            IImageRepository imageRepository,
            IUploadedFileRepository uploadedFileRepository,
            IChannelRepository channelRepository
        )
        {
            _userRepository = userRepository;
            _uploadService = uploadService;
            _videoRepository = videoRepository;
            _imageRepository = imageRepository;
            _uploadedFileRepository = uploadedFileRepository;
            _channelRepository = channelRepository;
        }

        public async Task<bool> Handle(NewVideoRequest request, IOutputPort<NewVideoResponse> outputPort)
        {
            if (_userRepository.FindById(request.UserId) == null)
            {
                outputPort.Handle(new NewVideoResponse(new[] { new Error(404, "user not found") }));
                return false;
            }
            if (_channelRepository.FindByUserId(request.UserId) == null)
            {
                outputPort.Handle(new NewVideoResponse(new[] { new Error(404, "you must have to create channel") }));
                return false;
            }

            UploadedFileDto videoInfo = await _uploadService.UploadFile(request.VideoFile, request.WebRootPath);
            UploadedFileDto previewInfo = await _uploadService.UploadFile(request.VideoPreview, request.WebRootPath);

            UploadedFileDto uploadedVideo = _uploadedFileRepository.Create(videoInfo);
            UploadedFileDto uploadedPreview = _uploadedFileRepository.Create(previewInfo);
            previewInfo.Id = uploadedPreview.Id;

            ImageDto videoPreview = _imageRepository.Create(new ImageDto() { UserId = request.UserId }, request.WebRootPath, previewInfo);
            var video = new VideoDto()
            {
                Description = request.Description,
                Name = request.Name,
                Views = 0,
                Likes = 0,
                Dislikes = 0,
                PreviewImageId = videoPreview.Id,
                UserId = request.UserId,
                UploadedFileId = uploadedVideo.Id,
            };
            VideoDto createdVideo = _videoRepository.Create(video);            
            outputPort.Handle(new NewVideoResponse(createdVideo));
            return true;
        }
    }
}
