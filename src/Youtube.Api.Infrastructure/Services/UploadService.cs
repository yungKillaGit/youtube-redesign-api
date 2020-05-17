using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces.Services;

namespace Youtube.Api.Infrastructure.Services
{
    public class UploadService : IUploadService
    {
        public async Task<UploadedFileDto> UploadFile(IFormFile file, string webRootPath)
        {
            string uniqueFileName = $"{Guid.NewGuid().ToString()}";
            string fileExtension = Path.GetExtension(file.FileName);

            string contentType = file.ContentType;
            string folder = "";
            bool isImage = false;
            if (contentType.StartsWith("video"))
            {
                folder = "videos";
            }
            else if (contentType.StartsWith("image"))
            {
                folder = "images";
                isImage = true;
            }
            else
            {
                throw new Exception("file content type is wrong");
            }

            string uploads = Path.Combine(webRootPath, folder);
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            string filePath = Path.Combine(uploads, $"{uniqueFileName}{fileExtension}");
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                stream.Close();                
            }                

            if (isImage)
            {
                string output = Path.Combine(uploads, $"{Guid.NewGuid().ToString()}{fileExtension}");
                ImageCompressor.Compress(400, 75, filePath, output);
                filePath = output;
            }

            return new UploadedFileDto()
            {
                FileName = uniqueFileName,                
                RelativePath = Path.GetRelativePath(webRootPath, filePath),
                UploadDate = DateTime.UtcNow,  
                ContentType = contentType,
            };
        }
    }
}
