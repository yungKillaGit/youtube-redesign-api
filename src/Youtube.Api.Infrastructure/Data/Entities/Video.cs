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

        public virtual UploadedFile IdNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<SectionedVideo> SectionedVideos { get; set; }
    }
}
