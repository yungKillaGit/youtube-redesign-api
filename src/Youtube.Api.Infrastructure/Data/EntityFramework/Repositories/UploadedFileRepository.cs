using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Infrastructure.Data.Entities;

namespace Youtube.Api.Infrastructure.Data.EntityFramework.Repositories
{
    public class UploadedFileRepository : IUploadedFileRepository
    {
        private readonly IMapper _mapper;
        private readonly YoutubeContext _database;

        public UploadedFileRepository(IMapper mapper, YoutubeContext database)
        {
            _mapper = mapper;
            _database = database;
        }

        public int Create(UploadedFileDto uploadedFileInfo)
        {
            var file = _mapper.Map<UploadedFile>(uploadedFileInfo);
            _database.UploadedFiles.Add(file);
            _database.SaveChanges();
            return file.Id;
        }
    }
}
