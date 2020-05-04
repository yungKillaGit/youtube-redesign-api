using System;
using System.Collections.Generic;

namespace Youtube.Api.Core.Dto.Entities
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime PostingDate { get; set; }
        public string Text { get; set; }
        public int VideoId { get; set; }

        public UserDto User { get; set; }
        public VideoDto Video { get; set; }
    }
}
