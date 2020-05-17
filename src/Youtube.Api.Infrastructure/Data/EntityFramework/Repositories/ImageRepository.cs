using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Infrastructure.Data.Entities;
using Youtube.Api.Infrastructure.Services;

namespace Youtube.Api.Infrastructure.Data.EntityFramework.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IMapper _mapper;
        private readonly YoutubeContext _database;

        public ImageRepository(IMapper mapper, YoutubeContext database)
        {
            _mapper = mapper;
            _database = database;
        }

        public ImageDto Create(ImageDto pictureInfo, string webRootPath, UploadedFileDto uploadedImage)
        {
            pictureInfo.UploadedFileId = uploadedImage.Id;
            pictureInfo.EncodedImage = FileEncoder.EncodeFile(uploadedImage.RelativePath, webRootPath);
            pictureInfo.ContentType = uploadedImage.ContentType;
            Image picture = _mapper.Map<Image>(pictureInfo);
            _database.Images.Add(picture);
            _database.SaveChanges();

            return _mapper.Map<ImageDto>(picture);
        }

        public ImageDto Get(int imageId)
        {
            return _mapper.Map<ImageDto>(_database.Images.Find(imageId));
        }
    }
}
