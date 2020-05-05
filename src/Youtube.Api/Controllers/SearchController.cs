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
    public class SearchController : ControllerBase
    {
        private readonly ISearchUseCase _searchUseCase;
        private readonly SearchPresenter _searchPresenter;
        private readonly IMapper _mapper;

        public SearchController(ISearchUseCase searchUseCase, SearchPresenter searchPresenter, IMapper mapper)
        {
            _searchUseCase = searchUseCase;
            _searchPresenter = searchPresenter;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Search([FromQuery] Models.Requests.SearchRequest request)
        {
            _searchUseCase.Handle(_mapper.Map<SearchRequest>(request), _searchPresenter);
            return _searchPresenter.ContentResult;
        }
    }
}