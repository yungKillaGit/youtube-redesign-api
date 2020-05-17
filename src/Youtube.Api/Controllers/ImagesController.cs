using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Api.Core.Dto;
using Youtube.Api.Core.Dto.Entities;
using Youtube.Api.Core.Interfaces.Gateways.Repositories;
using Youtube.Api.Presenters;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IImageRepository _imageRepository;
        private readonly IUploadedFileRepository _uploadedFileRepository;
        private readonly ErrorPresenter _basicPresenter;
        private readonly ImagePresenter _imagePresenter;

        public ImagesController(IWebHostEnvironment env, ImagePresenter imagePresenter, ErrorPresenter basicPresenter, IUploadedFileRepository uploadedFileRepository)
        {
            _env = env;
            _imagePresenter = imagePresenter;
            _basicPresenter = basicPresenter;
            _uploadedFileRepository = uploadedFileRepository;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int imageId)
        {
            UploadedFileDto image = _uploadedFileRepository.Get(imageId);
            if (image == null)
            {
                _basicPresenter.Handle(new Error(404, "image not found"));
            }
            string filePath = GetPhysicalPathFromRelativeUrl(image.RelativePath);
            _imagePresenter.Handle(Convert.ToBase64String(System.IO.File.ReadAllBytes(filePath)));
            return _imagePresenter.ContentResult;

            /*FileStream imageFile = System.IO.File.OpenRead(filePath);
            var file = File(imageFile, $"image/{Path.GetExtension(filePath).Substring(1)}", "image.jpg");
            return new { file = file };*/
        }

        private string GetPhysicalPathFromRelativeUrl(string url)
        {
            var path = Path.Combine(_env.WebRootPath, url.TrimStart('/').Replace("/", "\\"));
            return path;
        }
    }
}