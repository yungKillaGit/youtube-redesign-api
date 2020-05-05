using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Youtube.Api.Models.Requests
{
    public class NewChannelRequest
    {
        public int UserId { get; set; }
        public string RegistrationDate { get; set; }
        public string Description { get; set; }
    }
}
