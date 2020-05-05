using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseRequests
{
    public class NewChannelRequest : IUseCaseRequest<NewChannelResponse>
    {
        public int UserId { get; }
        public DateTime RegistrationDate { get; }
        public string Description { get; }
        public string Name { get; }

        public NewChannelRequest(int userId, DateTime registrationDate, string description, string name)
        {
            UserId = userId;
            RegistrationDate = registrationDate;
            Description = description;
        }
    }
}
