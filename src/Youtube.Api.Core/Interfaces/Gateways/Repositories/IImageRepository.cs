using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;

namespace Youtube.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IImageRepository
    {
        ImageDto Create(ImageDto pictureInfo, string webRootPath, UploadedFileDto uploadedImage);
        ImageDto Get(int imageId);
    }
}
