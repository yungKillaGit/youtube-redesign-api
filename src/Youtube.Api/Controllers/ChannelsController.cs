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
    public class ChannelsController : ControllerBase
    {
        private readonly INewChannelUseCase _newChannelUseCase;
        private readonly ISubscriptionProcessingUseCase _subscriptionProcessingUseCase;
        private readonly NewChannelPresenter _newChannelPresenter;
        private readonly SubscriptionProcessingPresenter _subscriptionProcessingPresenter;        
        private readonly NewChannelValidator _newChannelValidator;

        public ChannelsController(
            ISubscriptionProcessingUseCase subscriptionProcessingUseCase,
            INewChannelUseCase newChannelUseCase,
            NewChannelPresenter newChannelPresenter,
            SubscriptionProcessingPresenter subscriptionProcessingPresenter,            
            NewChannelValidator newChannelValidator
        )
        {
            _subscriptionProcessingUseCase = subscriptionProcessingUseCase;
            _newChannelUseCase = newChannelUseCase;
            _newChannelPresenter = newChannelPresenter;
            _subscriptionProcessingPresenter = subscriptionProcessingPresenter;            
            _newChannelValidator = newChannelValidator;
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateChannel([FromBody] Models.Requests.NewChannelRequest request)
        {
            try
            {
                _newChannelValidator.ValidateAndThrow(request);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Errors);
            }
            var newChannelRequest = new NewChannelRequest(
                int.Parse(User.Id()),
                DateTime.Now,
                request.Description,
                request.Name
            );
            _newChannelUseCase.Handle(newChannelRequest, _newChannelPresenter);
            return _newChannelPresenter.ContentResult;
        }

        [Authorize]
        [HttpPost("subscription")]
        public ActionResult Subscribe([FromQuery] Models.Requests.SubscriptionProcessingRequest request)
        {
            var subscriptionProcessingRequest = new SubscriptionProcessingRequest(request.ChannelId, int.Parse(User.Id()));
            _subscriptionProcessingUseCase.Handle(subscriptionProcessingRequest, _subscriptionProcessingPresenter);
            return _subscriptionProcessingPresenter.ContentResult;
        }
    }
}