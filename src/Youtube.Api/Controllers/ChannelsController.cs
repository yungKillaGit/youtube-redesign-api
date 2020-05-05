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
        private readonly NewChannelPresenter _newChannelPresenter;
        private readonly IMapper _mapper;

        public ChannelsController(INewChannelUseCase newChannelUseCase, NewChannelPresenter newChannelPresenter, IMapper mapper)
        {
            _newChannelUseCase = newChannelUseCase;
            _newChannelPresenter = newChannelPresenter;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateChannel([FromBody] Models.Requests.NewChannelRequest request)
        {
            _newChannelUseCase.Handle(_mapper.Map<NewChannelRequest>(request), _newChannelPresenter);
            return _newChannelPresenter.ContentResult;
        }
    }
}