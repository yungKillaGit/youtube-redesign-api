using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Youtube.Api.Models.Requests
{
    public class UploadFileRequest
    {
        public IFormFile File { get; set; }
        public int? UserId { get; set; }
    }
}
