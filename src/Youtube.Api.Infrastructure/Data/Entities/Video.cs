using System;
using System.Collections.Generic;

namespace Youtube.Api.Infrastructure.Data.Entities
{
    public partial class Video
    {
        public Video()
        {
            Comments = new HashSet<Comment>();
            SectionedVideos = new HashSet<SectionedVideo>();
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

        public virtual Image PreviewImage { get; set; }
        public virtual UploadedFile UploadedFile { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<SectionedVideo> SectionedVideos { get; set; }
    }
}
