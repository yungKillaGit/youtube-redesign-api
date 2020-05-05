using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Youtube.Api.Models.Requests
{
    public class NewCommentRequest
    {        
        public int UserId { get; set; }
        public string PostingDate { get; set; }
        public string Text { get; set; }
        public int VideoId { get; set; }
    }
}
