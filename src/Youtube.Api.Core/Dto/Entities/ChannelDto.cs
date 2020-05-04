using System;
using System.Collections.Generic;

namespace Youtube.Api.Core.Dto.Entities
{
    public class ChannelDto
    {
        public ChannelDto()
        {
            ChannelSubscribers = new HashSet<ChannelSubscriberDto>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Description { get; set; }

        public UserDto User { get; set; }
        public ICollection<ChannelSubscriberDto> ChannelSubscribers { get; set; }
    }
}
