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
            UploadedFiles = new HashSet<UploadedFileDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string PasswordHash { get; set; }
        public int? ProfilePictureId { get; set; }

        public ProfilePictureDto ProfilePicture { get; set; }
        public ChannelDto Channels { get; set; }
        public ICollection<ChannelSubscriberDto> ChannelSubscribers { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<SectionedVideoDto> SectionedVideos { get; set; }
        public ICollection<UploadedFileDto> UploadedFiles { get; set; }
    }
}
