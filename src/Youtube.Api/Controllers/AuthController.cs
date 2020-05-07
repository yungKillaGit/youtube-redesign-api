using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Youtube.Api.Core.Interfaces.UseCases;
using Youtube.Api.Infrastructure.Auth;
using Youtube.Api.Presenters;
using Youtube.Api.Validators;

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
        private readonly LoginValidator _loginValidator;
        private readonly RegisterValidator _registerValidator;
        private readonly IWebHostEnvironment _env;

        public AuthController
        (
            ILoginUseCase loginUseCase,
            IRegisterUserUseCase registerUserUseCase,
            LoginPresenter loginPresenter,
            RegisterUserPresenter registerUserPresenter,            
            LoginValidator loginValidator,
            RegisterValidator registerValidator,
            IWebHostEnvironment env
        )
        {
            _loginUseCase = loginUseCase;
            _registerUserUseCase = registerUserUseCase;
            _loginPresenter = loginPresenter;
            _registerUserPresenter = registerUserPresenter;
            _loginValidator = loginValidator;
            _registerValidator = registerValidator;
            _env = env;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] Models.Requests.LoginRequest request)
        {
            try
            {
                _loginValidator.ValidateAndThrow(request);
            }            
            catch (ValidationException e)
            {
                return BadRequest(e.Errors);
            }
            _loginUseCase.Handle(new LoginRequest(request.Email, Cipher.Encrypt(request.Password)), _loginPresenter);

            return _loginPresenter.ContentResult;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromForm] Models.Requests.RegisterUserRequest request)
        {
            try
            {
                _registerValidator.ValidateAndThrow(request);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Errors);
            }
            var registerUserRequest = new RegisterUserRequest(
                request.Name,
                request.Email,
                DateTime.Parse(request.BirthDay),
                Cipher.Encrypt(request.Password),
                request.Picture,
                _env.WebRootPath
            );
            await _registerUserUseCase.Handle(registerUserRequest, _registerUserPresenter);

            return _registerUserPresenter.ContentResult;
        }
    }
}