using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Dto.GatewayResponses.Repositories;

namespace Youtube.Api.Core.Interfaces.Gateways.Repositories
{
    public interface ISectionRepository
    {
        int Create(SectionDto sectionInfo);
        IEnumerable<SectionDto> GetSections();
        SectionVideosResponse GetSectionVideos(int userId, string sectionName);
    }
}
