using System;
using System.Collections.Generic;

namespace Youtube.Api.Core.Dto.Entities
{
    public class ChannelSubscriberDto
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public int UserId { get; set; }

        public ChannelDto Channel { get; set; }
        public UserDto User { get; set; }
    }
}
