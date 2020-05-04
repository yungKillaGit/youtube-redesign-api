using System;
using System.Collections.Generic;

namespace Youtube.Api.Core.Dto.Entities
{
    public class SectionedVideoDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public int SectionId { get; set; }

        public SectionDto Section { get; set; }
        public UserDto User { get; set; }
        public VideoDto Video { get; set; }
    }
}
