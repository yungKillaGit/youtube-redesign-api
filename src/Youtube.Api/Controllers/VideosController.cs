using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Core.Interfaces.UseCases;
using Youtube.Api.Extensions;
using Youtube.Api.Presenters;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly ILikeProcessingUseCase _likeProcessingUseCase;
        private readonly LikeProcessingPresenter _likeProcessingPresenter;
        private readonly IDislikeProcessingUseCase _dislikeProcessingUseCase;
        private readonly DislikeProcessingPresenter _dislikeProcessingPresenter;
        private readonly IViewProcessingUseCase _viewProcessingUseCase;
        private readonly ViewProcessingPresenter _viewProcessingPresenter;

        public VideosController(
            ILikeProcessingUseCase likeProcessingUseCase,
            LikeProcessingPresenter likeProcessingPresenter,
            IDislikeProcessingUseCase dislikeProcessingUseCase,
            DislikeProcessingPresenter dislikeProcessingPresenter,
            IViewProcessingUseCase viewProcessingUseCase,
            ViewProcessingPresenter viewProcessingPresenter
        )
        {
            _likeProcessingPresenter = likeProcessingPresenter;
            _likeProcessingUseCase = likeProcessingUseCase;
            _dislikeProcessingPresenter = dislikeProcessingPresenter;
            _dislikeProcessingUseCase = dislikeProcessingUseCase;
            _viewProcessingPresenter = viewProcessingPresenter;
            _viewProcessingUseCase = viewProcessingUseCase;
        }


        [Authorize]
        [HttpPost("like")]
        public ActionResult HandleLike([FromQuery] Models.Requests.LikeProccessingRequest request)
        {
            var likeProcessingRequest = new LikeProcessingRequest(int.Parse(User.Id()), request.VideoId);
            _likeProcessingUseCase.Handle(likeProcessingRequest, _likeProcessingPresenter);
            return _likeProcessingPresenter.ContentResult;
        }

        [Authorize]
        [HttpPost("dislike")]
        public ActionResult HandleDislike([FromQuery] Models.Requests.DislikeProcessingRequest request)
        {
            var dislikeProcessingRequest = new DislikeProcessingRequest(int.Parse(User.Id()), request.VideoId);
            _dislikeProcessingUseCase.Handle(dislikeProcessingRequest, _dislikeProcessingPresenter);
            return _dislikeProcessingPresenter.ContentResult;
        }
        
        [HttpPost("view")]
        public ActionResult HandleView([FromQuery] Models.Requests.ViewProcessingRequest request)
        {
            string currentId = User.Id();
            int? userId = null;
            if (currentId != null)
            {
                userId = int.Parse(currentId);
            }
            var viewProcessingRequest = new ViewProcessingRequest(userId, request.VideoId);
            _viewProcessingUseCase.Handle(viewProcessingRequest, _viewProcessingPresenter);
            return _viewProcessingPresenter.ContentResult;
        }
    }
}