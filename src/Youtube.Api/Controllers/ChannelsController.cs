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
    public class ChannelsController : ControllerBase
    {
        private readonly INewChannelUseCase _newChannelUseCase;
        private readonly INewSubscriberUseCase _newSubscriberUseCase;
        private readonly NewChannelPresenter _newChannelPresenter;
        private readonly NewSubscriberPresenter _newSubscriberPresenter;
        private readonly IMapper _mapper;

        public ChannelsController(
            INewSubscriberUseCase newSubscriberUseCase,
            INewChannelUseCase newChannelUseCase,
            NewChannelPresenter newChannelPresenter,
            NewSubscriberPresenter newSubscriberPresenter,
            IMapper mapper
        )
        {
            _newSubscriberUseCase = newSubscriberUseCase;
            _newChannelUseCase = newChannelUseCase;
            _newChannelPresenter = newChannelPresenter;
            _newSubscriberPresenter = newSubscriberPresenter;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateChannel([FromBody] Models.Requests.NewChannelRequest request)
        {
            _newChannelUseCase.Handle(_mapper.Map<NewChannelRequest>(request), _newChannelPresenter);
            return _newChannelPresenter.ContentResult;
        }

        [HttpPost("new-subscriber")]
        public ActionResult Subscribe([FromBody] Models.Requests.NewSubscriberRequest request)
        {
            _newSubscriberUseCase.Handle(_mapper.Map<NewSubscriberRequest>(request), _newSubscriberPresenter);
            return _newSubscriberPresenter.ContentResult;
        }
    }
}