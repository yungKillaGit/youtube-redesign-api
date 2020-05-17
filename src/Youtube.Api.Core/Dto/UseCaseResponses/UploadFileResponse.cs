using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class UploadFileResponse : UseCaseResponseMessage
    {
        public Error Error { get; }

        public UploadFileResponse(Error error)
        {
            Error = error;
        }

        public UploadFileResponse(bool success = true, string message = "file successfuly uploaded") : base(success, message)
        {

        }
    }
}
