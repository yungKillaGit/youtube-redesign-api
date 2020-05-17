using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;

namespace Youtube.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IVideoRepository
    {
        VideoDto FindById(int id);
        IEnumerable<VideoDto> FindByName(string name);
        IEnumerable<VideoDto> FindByUserId(int userId);
        VideoDto Create(VideoDto videoInfo);
        void HandleLike(int videoId, int userId);
        void HandleDislike(int videoId, int userId);
        void HandleView(int videoId, int? userId);
        IEnumerable<VideoDto> GetAllVideos();
    }
}
