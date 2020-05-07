using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Dto.GatewayResponses.Repositories;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Infrastructure.Data.Entities;
using Youtube.Api.Infrastructure.Helpers;

namespace Youtube.Api.Infrastructure.Data.EntityFramework.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly IMapper _mapper;
        private readonly YoutubeContext _database;

        public SectionRepository(IMapper mapper, YoutubeContext database)
        {
            _mapper = mapper;
            _database = database;
        }

        public int Create(SectionDto sectionInfo)
        {
            var section = _mapper.Map<Section>(sectionInfo);
            _database.Sections.Add(section);
            _database.SaveChanges();

            return section.Id;
        }

        public IEnumerable<SectionDto> GetSections()
        {
            return _mapper.Map<IEnumerable<SectionDto>>(_database.Sections);
        }

        public SectionVideosResponse GetSectionVideos(int userId, string sectionName)
        {            
            Section section = _database.Sections.Where(x => x.Name.ToLower() == sectionName).FirstOrDefault();
            if (section == null)
            {
                throw new NotImplementedException($"{sectionName} section doesnt exist");
            }
            IEnumerable<Video> videos = _database
                .SectionedVideos
                .Where(x => x.SectionId == section.Id && x.UserId == userId)
                .Select(x => x.Video)
                .ToList();
            return new SectionVideosResponse(section.Id, _mapper.Map<IEnumerable<VideoDto>>(videos));
        }
    }
}
