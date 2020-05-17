using System;
using System.Collections.Generic;

namespace Youtube.Api.Infrastructure.Data.Entities
{
    public partial class Image
    {
        public int Id { get; set; }
        public int UploadedFileId { get; set; }
        public int UserId { get; set; }
        public string EncodedImage { get; set; }
        public string ContentType { get; set; }

        public virtual UploadedFile UploadedFile { get; set; }
        public virtual User User { get; set; }
        public virtual User Users { get; set; }
        public virtual Video Video { get; set; }
    }
}
