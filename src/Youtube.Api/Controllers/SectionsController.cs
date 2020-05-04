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

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly SectionListPresenter _allSectionsPresenter;
        private readonly NewSectionPresenter _newSectionPresenter;
        private readonly ISectionListUseCase _getSectionsUseCase;
        private readonly INewSectionUseCase _newSectionUseCase;

        public SectionsController
        (
            SectionListPresenter allSectionsPresenter,
            NewSectionPresenter newSectionPresenter,
            ISectionListUseCase getSectionsUseCase,
            INewSectionUseCase newSectionUseCase
        )
        {
            _allSectionsPresenter = allSectionsPresenter;
            _newSectionPresenter = newSectionPresenter;
            _getSectionsUseCase = getSectionsUseCase;
            _newSectionUseCase = newSectionUseCase;
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetSections()
        {
            _getSectionsUseCase.Handle(_allSectionsPresenter);

            return _allSectionsPresenter.ContentResult;
        }

        [HttpPost]
        public ActionResult CreateSection([FromBody] Models.Requests.NewSectionRequest request)
        {
            _newSectionUseCase.Handle(new NewSectionRequest(request.Name), _newSectionPresenter);

            return _newSectionPresenter.ContentResult;
        }
    }
}