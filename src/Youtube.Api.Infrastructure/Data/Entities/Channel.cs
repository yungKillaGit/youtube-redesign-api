using System;
using System.Collections.Generic;

namespace Youtube.Api.Infrastructure.Data.Entities
{
    public partial class Channel
    {
        public Channel()
        {
            ChannelSubscribers = new HashSet<ChannelSubscriber>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ChannelSubscriber> ChannelSubscribers { get; set; }
    }
}
