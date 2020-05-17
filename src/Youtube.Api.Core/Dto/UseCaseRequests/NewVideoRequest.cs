using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseRequests
{
    public class NewVideoRequest : IUseCaseRequest<NewVideoResponse>
    {
        public IFormFile VideoFile { get; }
        public IFormFile VideoPreview { get; }
        public string Description { get; }
        public string Name { get; }
        public int UserId { get; }
        public string WebRootPath { get; }

        public NewVideoRequest(IFormFile videoFile, IFormFile videoPreview, string description, string name, int userId, string webRootPath)
        {
            VideoPreview = videoPreview;
            VideoFile = videoFile;
            Description = description;
            Name = name;
            UserId = userId;
            WebRootPath = webRootPath;
        }
    }
}
