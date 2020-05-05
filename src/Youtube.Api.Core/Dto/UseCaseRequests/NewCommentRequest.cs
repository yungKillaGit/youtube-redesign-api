using System;
using System.Collections.Generic;
using System.Text;
using Youtube.Api.Core.Dto.UseCaseResponses;
using Youtube.Api.Core.Interfaces;

namespace Youtube.Api.Core.Dto.UseCaseRequests
{
    public class NewCommentRequest : IUseCaseRequest<NewCommentResponse>
    {        
        public int UserId { get; }
        public DateTime PostingDate { get; }
        public string Text { get; }
        public int VideoId { get; }

        public NewCommentRequest(int userId, DateTime postingDate, string text, int videoId)
        {            
            UserId = userId;
            PostingDate = postingDate;
            Text = text;
            VideoId = videoId;
        }
    }
}
