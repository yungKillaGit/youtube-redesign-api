using System;
using System.Collections.Generic;

namespace Youtube.Api.Core.Dto.Entities
{
    public class UserDto
    {
        public UserDto()
        {
            ChannelSubscribers = new HashSet<ChannelSubscriberDto>();
            Comments = new HashSet<CommentDto>();            
            SectionedVideos = new HashSet<SectionedVideoDto>();
            Videos = new HashSet<VideoDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string PasswordHash { get; set; }
        public int? ImageId { get; set; }

        public virtual ImageDto Image { get; set; }
        public virtual ChannelDto Channel { get; set; }
        public virtual ICollection<ChannelSubscriberDto> ChannelSubscribers { get; set; }
        public virtual ICollection<CommentDto> Comments { get; set; }        
        public virtual ICollection<SectionedVideoDto> SectionedVideos { get; set; }
        public virtual ICollection<VideoDto> Videos { get; set; }
    }
}
