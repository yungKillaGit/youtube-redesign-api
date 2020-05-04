using System;
using System.Collections.Generic;

namespace Youtube.Api.Core.Dto.Entities
{
    public class ProfilePictureDto
    {
        public int Id { get; set; }

        public UploadedFileDto IdNavigation { get; set; }
        public UserDto Users { get; set; }
    }
}
