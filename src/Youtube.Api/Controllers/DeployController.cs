using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Api.Infrastructure.Data;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeployController : ControllerBase
    {
        private readonly Seeder _seeder;

        public DeployController(Seeder seeder)
        {
            _seeder = seeder;
        }

        [HttpPost]
        public ActionResult Deploy()
        {
            _seeder.Seed();
            return Ok();
        }
    }
}