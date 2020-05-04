using System;
using System.Collections.Generic;

namespace Youtube.Api.Infrastructure.Data.Entities
{
    public partial class UploadedFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string RelativePath { get; set; }
        public string FileExtension { get; set; }
        public DateTime UploadDate { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ProfilePicture ProfilePictures { get; set; }
        public virtual Video Videos { get; set; }
    }
}
