using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Youtube.Api.Models.Requests
{
    public class NewSubscriberRequest
    {
        public int ChannelId { get; set; }
        public int UserId { get; set; }
    }
}
