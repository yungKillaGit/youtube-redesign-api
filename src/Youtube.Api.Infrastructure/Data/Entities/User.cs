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
            SectionedVideos = new HashSet<SectionedVideo>();
            UploadedFiles = new HashSet<UploadedFile>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string PasswordHash { get; set; }
        public int? ProfilePictureId { get; set; }

        public virtual ProfilePicture ProfilePicture { get; set; }
        public virtual Channel Channels { get; set; }
        public virtual ICollection<ChannelSubscriber> ChannelSubscribers { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<SectionedVideo> SectionedVideos { get; set; }
        public virtual ICollection<UploadedFile> UploadedFiles { get; set; }
    }
}
