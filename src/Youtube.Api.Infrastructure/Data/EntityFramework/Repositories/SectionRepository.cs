using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Infrastructure.Data.Entities;

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
    }
}
