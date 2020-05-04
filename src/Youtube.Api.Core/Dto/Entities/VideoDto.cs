using System;
using System.Collections.Generic;

namespace Youtube.Api.Core.Dto.Entities
{
    public class VideoDto
    {
        public VideoDto()
        {
            Comments = new HashSet<CommentDto>();
            SectionedVideos = new HashSet<SectionedVideoDto>();
        }

        public int Id { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string Description { get; set; }

        public UploadedFileDto IdNavigation { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<SectionedVideoDto> SectionedVideos { get; set; }
    }
}
