using System;
using System.Collections.Generic;

namespace Youtube.Api.Infrastructure.Data.Entities
{
    public partial class User
    {
        public User()
        {
            ChannelSubscribers = new HashSet<ChannelSubscriber>();
            Comments = new HashSet<Comment>();
            Images = new HashSet<Image>();
            SectionedVideos = new HashSet<SectionedVideo>();
            Videos = new HashSet<Video>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string PasswordHash { get; set; }
        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }
        public virtual Channel Channel { get; set; }
        public virtual ICollection<ChannelSubscriber> ChannelSubscribers { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<SectionedVideo> SectionedVideos { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
