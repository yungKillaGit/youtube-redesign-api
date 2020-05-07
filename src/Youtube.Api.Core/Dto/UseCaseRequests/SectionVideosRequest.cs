using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseRequests
{
    public class SectionVideosRequest : IUseCaseRequest<SectionVideosResponse>
    {
        public int UserId { get; }
        public string SectionName { get; }

        public SectionVideosRequest(int userId, string sectionName)
        {
            UserId = userId;
            SectionName = sectionName;
        }
    }
}
