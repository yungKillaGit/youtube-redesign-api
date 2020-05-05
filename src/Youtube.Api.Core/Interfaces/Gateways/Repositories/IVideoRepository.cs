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
        int Create(VideoDto videoInfo);
        void HandleLike(int videoId);
    }
}
