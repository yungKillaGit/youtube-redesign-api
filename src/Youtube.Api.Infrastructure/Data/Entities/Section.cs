using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Youtube.Api.Infrastructure.Data.Entities
{
    public partial class Section
    {
        public Section()
        {
            SectionedVideos = new HashSet<SectionedVideo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SectionedVideo> SectionedVideos { get; set; }
    }
}
