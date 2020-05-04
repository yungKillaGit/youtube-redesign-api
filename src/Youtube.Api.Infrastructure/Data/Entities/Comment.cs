using System;
using System.Collections.Generic;

namespace Youtube.Api.Infrastructure.Data.Entities
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime PostingDate { get; set; }
        public string Text { get; set; }
        public int VideoId { get; set; }

        public virtual User User { get; set; }
        public virtual Video Video { get; set; }
    }
}
