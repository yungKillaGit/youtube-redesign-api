using System;
using System.Collections.Generic;

namespace Youtube.Api.Infrastructure.Data.Entities
{
    public partial class SectionedVideo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public int SectionId { get; set; }

        public virtual Section Section { get; set; }
        public virtual User User { get; set; }
        public virtual Video Video { get; set; }
    }
}
