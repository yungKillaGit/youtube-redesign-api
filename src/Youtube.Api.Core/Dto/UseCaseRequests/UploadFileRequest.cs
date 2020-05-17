using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseRequests
{
    public class UploadFileRequest : IUseCaseRequest<UploadFileResponse>
    {
        public int UserId { get; }
        public IFormFile File { get; }
        public string WebRootPath { get; }

        public UploadFileRequest(int userId, IFormFile file, string webRootPath)
        {
            UserId = userId;
            File = file;
            WebRootPath = webRootPath;
        }
    }
}
