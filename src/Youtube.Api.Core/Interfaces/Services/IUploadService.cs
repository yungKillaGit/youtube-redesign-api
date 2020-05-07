using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.Entities;

namespace Youtube.Api.Core.Interfaces.Services
{
    public interface IUploadService
    {
        public Task<UploadedFileDto> UploadFile(IFormFile file, int userId, string webRootPath);
    }
}
