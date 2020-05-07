using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Infrastructure.Data.Entities;

namespace Youtube.Api.Infrastructure.Data.EntityFramework.Repositories
{
    public class ProfilePictureRepository : IProfilePictureRepository
    {
        private readonly IMapper _mapper;
        private readonly YoutubeContext _database;

        public ProfilePictureRepository(IMapper mapper, YoutubeContext database)
        {
            _mapper = mapper;
            _database = database;
        }

        public int Create(ProfilePictureDto pictureInfo)
        {
            var picture = _mapper.Map<ProfilePicture>(pictureInfo);
            _database.ProfilePictures.Add(picture);
            _database.SaveChanges();
            return picture.Id;
        }
    }
}
