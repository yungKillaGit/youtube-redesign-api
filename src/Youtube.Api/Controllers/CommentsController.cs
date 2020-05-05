using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Core.Interfaces.UseCases;
using Youtube.Api.Presenters;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly NewCommentPresenter _newCommentPresenter;
        private readonly INewCommentUseCase _newCommentUseCase;
        private readonly IMapper _mapper;

        public CommentsController(NewCommentPresenter newCommentPresenter, INewCommentUseCase newCommentUseCase, IMapper mapper)
        {
            _newCommentPresenter = newCommentPresenter;
            _newCommentUseCase = newCommentUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateComment([FromBody] Models.Requests.NewCommentRequest request)
        {
            var newCommentRequest = _mapper.Map<NewCommentRequest>(request);
            _newCommentUseCase.Handle(newCommentRequest, _newCommentPresenter);

            return _newCommentPresenter.ContentResult;
        }
    }
}