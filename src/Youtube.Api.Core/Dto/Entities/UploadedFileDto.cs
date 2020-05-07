using System;
using System.Collections.Generic;

namespace Youtube.Api.Core.Dto.Entities
{
    public class UploadedFileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string RelativePath { get; set; }        
        public DateTime UploadDate { get; set; }
        public int UserId { get; set; }

        public UserDto User { get; set; }
        public ProfilePictureDto ProfilePictures { get; set; }
        public VideoDto Videos { get; set; }
    }
}
