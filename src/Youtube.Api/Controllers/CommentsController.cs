using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Core.Interfaces.UseCases;
using Youtube.Api.Extensions;
using Youtube.Api.Presenters;
using Youtube.Api.Validators;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly NewCommentPresenter _newCommentPresenter;
        private readonly INewCommentUseCase _newCommentUseCase;        
        private readonly NewCommentValidator _newCommentValidator;

        public CommentsController(
            NewCommentPresenter newCommentPresenter,
            INewCommentUseCase newCommentUseCase,
            NewCommentValidator newCommentValidator
        )
        {
            _newCommentPresenter = newCommentPresenter;
            _newCommentUseCase = newCommentUseCase;            
            _newCommentValidator = newCommentValidator;
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateComment([FromBody] Models.Requests.NewCommentRequest request)
        {
            try
            {
                _newCommentValidator.ValidateAndThrow(request);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Errors);
            }
            var newCommentRequest = new NewCommentRequest(
                int.Parse(User.Id()),
                DateTime.Parse(request.PostingDate),
                request.Text,
                request.VideoId
            );
            _newCommentUseCase.Handle(newCommentRequest, _newCommentPresenter);

            return _newCommentPresenter.ContentResult;
        }
    }
}