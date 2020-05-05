using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;

namespace Youtube.Api.Infrastructure.Data.EntityFramework.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly IMapper _mapper;
        private readonly YoutubeContext _database;

        public VideoRepository(IMapper mapper, YoutubeContext database)
        {
            _mapper = mapper;
            _database = database;
        }

        public int Create(VideoDto videoInfo)
        {
            throw new NotImplementedException();
        }

        public VideoDto FindById(int id)
        {
            return _mapper.Map<VideoDto>(_database.Videos.Find(id));
        }
    }
}
