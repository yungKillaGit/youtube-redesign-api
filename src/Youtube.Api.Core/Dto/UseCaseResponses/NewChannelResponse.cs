using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseResponses
{
    public class NewChannelResponse : UseCaseResponseMessage
    {
        public ChannelDto Channel { get; }
        public IEnumerable<Error> Errors { get; }

        public NewChannelResponse(ChannelDto channel, bool success = true, string message = null) : base(success, message)
        {
            Channel = channel;
        }

        public NewChannelResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
