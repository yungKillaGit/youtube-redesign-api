using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    public class SearchController : ControllerBase
    {
        private readonly ISearchUseCase _searchUseCase;
        private readonly SearchPresenter _searchPresenter;        

        public SearchController(ISearchUseCase searchUseCase, SearchPresenter searchPresenter)
        {
            _searchUseCase = searchUseCase;
            _searchPresenter = searchPresenter;
        }

        [HttpGet]
        public ActionResult Search([FromQuery] Models.Requests.SearchRequest request)
        {
            if (String.IsNullOrEmpty(request.SearchQuery))
            {
                return BadRequest(new { error = "search query must be non-empty string" });
            }
            _searchUseCase.Handle(new SearchRequest(Regex.Replace(request.SearchQuery, @"\s+", " ").ToLower()), _searchPresenter);
            return _searchPresenter.ContentResult;
        }
    }
}