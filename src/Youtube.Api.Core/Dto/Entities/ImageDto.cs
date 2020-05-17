using System;
using System.Collections.Generic;

namespace Youtube.Api.Core.Dto.Entities
{
    public class ImageDto
    {
        public int Id { get; set; }
        public int UploadedFileId { get; set; }
        public int UserId { get; set; }
        public string EncodedImage { get; set; }
        public string ContentType { get; set; }

        public virtual UploadedFileDto UploadedFile { get; set; }        
        public virtual VideoDto Video { get; set; }
    }
}
