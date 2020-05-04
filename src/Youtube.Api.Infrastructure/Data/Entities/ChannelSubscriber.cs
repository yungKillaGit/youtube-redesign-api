using System;
using System.Collections.Generic;

namespace Youtube.Api.Infrastructure.Data.Entities
{
    public partial class ChannelSubscriber
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public int UserId { get; set; }

        public virtual Channel Channel { get; set; }
        public virtual User User { get; set; }
    }
}
