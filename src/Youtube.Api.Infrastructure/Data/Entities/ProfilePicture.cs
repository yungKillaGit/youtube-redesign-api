using System;
using System.Collections.Generic;

namespace Youtube.Api.Infrastructure.Data.Entities
{
    public partial class ProfilePicture
    {
        public int Id { get; set; }
        public virtual UploadedFile IdNavigation { get; set; }
        public virtual User Users { get; set; }
    }
}
