using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Api.Core.Interfaces.UseCases;
using Youtube.Api.Presenters;
using Youtube.Api.Core.Dto.UseCaseRequests;
using Microsoft.AspNetCore.Authorization;
using Youtube.Api.Extensions;
using Youtube.Api.Infrastructure.Helpers;
using System.Text.RegularExpressions;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {        
        private readonly ISectionVideosUseCase _sectionVideosUseCase;
        private readonly SectionVideosPresenter _sectionVideosPresenter;

        public SectionsController
        (            
            ISectionVideosUseCase sectionVideosUseCase,
            SectionVideosPresenter sectionVideosPresenter
        )
        {            
            _sectionVideosPresenter = sectionVideosPresenter;
            _sectionVideosUseCase = sectionVideosUseCase;
        }

        [Authorize]
        [HttpGet("videos")]
        public ActionResult GetSectionVideos([FromQuery] Models.Requests.SectionVideosRequest request)
        {
            var allowedSections = new List<string>
            {
                Constants.Strings.Sections.Disliked,
                Constants.Strings.Sections.Liked,
                Constants.Strings.Sections.History,
            };
            allowedSections.ForEach(x => x.ToLower());
            string sectionName = Regex.Replace(request.SectionName, @"\s+", " ").ToLower();
            if (!allowedSections.Contains(sectionName))
            {
                return BadRequest(new { Error = "required section is not alloweed or its name is wrong" });
            }
            _sectionVideosUseCase.Handle(new SectionVideosRequest(int.Parse(User.Id()), sectionName), _sectionVideosPresenter);
            return _sectionVideosPresenter.ContentResult;
        }
    }
}