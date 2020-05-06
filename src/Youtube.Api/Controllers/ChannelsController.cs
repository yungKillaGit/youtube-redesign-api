using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class ChannelsController : ControllerBase
    {
        private readonly INewChannelUseCase _newChannelUseCase;
        private readonly ISubscriptionProcessingUseCase _subscriptionProcessingUseCase;
        private readonly NewChannelPresenter _newChannelPresenter;
        private readonly SubscriptionProcessingPresenter _subscriptionProcessingPresenter;
        private readonly IMapper _mapper;

        public ChannelsController(
            ISubscriptionProcessingUseCase subscriptionProcessingUseCase,
            INewChannelUseCase newChannelUseCase,
            NewChannelPresenter newChannelPresenter,
            SubscriptionProcessingPresenter subscriptionProcessingPresenter,
            IMapper mapper
        )
        {
            _subscriptionProcessingUseCase = subscriptionProcessingUseCase;
            _newChannelUseCase = newChannelUseCase;
            _newChannelPresenter = newChannelPresenter;
            _subscriptionProcessingPresenter = subscriptionProcessingPresenter;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateChannel([FromBody] Models.Requests.NewChannelRequest request)
        {
            _newChannelUseCase.Handle(_mapper.Map<NewChannelRequest>(request), _newChannelPresenter);
            return _newChannelPresenter.ContentResult;
        }

        [Authorize]
        [HttpPost("subscription")]
        public ActionResult Subscribe([FromQuery] Models.Requests.SubscriptionProcessingRequest request)
        {
            var subscriptionProcessingRequest = new SubscriptionProcessingRequest(request.ChannelId, User.Id());
            _subscriptionProcessingUseCase.Handle(subscriptionProcessingRequest, _subscriptionProcessingPresenter);
            return _subscriptionProcessingPresenter.ContentResult;
        }
    }
}