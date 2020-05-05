using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;

namespace Youtube.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IVideoRepository
    {
        VideoDto FindById(int id);
        int Create(VideoDto videoInfo);
    }
}
