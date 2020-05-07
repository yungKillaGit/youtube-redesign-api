using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Youtube.Api.Models.Requests
{
    public class NewVideoRequest
    {        
        public IFormFile VideoFile { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }        
    }
}
