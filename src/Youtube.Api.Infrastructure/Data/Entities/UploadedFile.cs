using System;
using System.Collections.Generic;

namespace Youtube.Api.Infrastructure.Data.Entities
{
    public partial class UploadedFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string RelativePath { get; set; }
        public DateTime UploadDate { get; set; }

        public virtual Image Image { get; set; }
        public virtual Video Video { get; set; }
    }
}
