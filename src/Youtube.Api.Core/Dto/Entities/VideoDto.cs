using System;
using System.Collections.Generic;

namespace Youtube.Api.Core.Dto.Entities
{
    public class VideoDto
    {
        public VideoDto()
        {
            Comments = new HashSet<CommentDto>();            
        }

        public int Id { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int UploadedFileId { get; set; }
        public int UserId { get; set; }
        public int PreviewImageId { get; set; }

        public virtual ImageDto PreviewImage { get; set; }        
        public virtual UserDto User { get; set; }
        public virtual ICollection<CommentDto> Comments { get; set; }        
    }
}
