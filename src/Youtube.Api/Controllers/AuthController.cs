using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Core.Interfaces.UseCases;
using Youtube.Api.Infrastructure.Auth;
using Youtube.Api.Presenters;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginUseCase _loginUseCase;
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly LoginPresenter _loginPresenter;
        private readonly RegisterUserPresenter _registerUserPresenter;
        private readonly IMapper _mapper;

        public AuthController
        (
            ILoginUseCase loginUseCase,
            IRegisterUserUseCase registerUserUseCase,
            LoginPresenter loginPresenter,
            RegisterUserPresenter registerUserPresenter,
            IMapper mapper
        )
        {
            _loginUseCase = loginUseCase;
            _registerUserUseCase = registerUserUseCase;
            _loginPresenter = loginPresenter;
            _registerUserPresenter = registerUserPresenter;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] Models.Requests.LoginRequest request)
        {            
            _loginUseCase.Handle(new LoginRequest(request.Email, Cipher.Encrypt(request.Password)), _loginPresenter);

            return _loginPresenter.ContentResult;
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] Models.Requests.RegisterUserRequest request)
        {
            _registerUserUseCase.Handle(_mapper.Map<RegisterUserRequest>(request), _registerUserPresenter);

            return _registerUserPresenter.ContentResult;
        }
    }
}