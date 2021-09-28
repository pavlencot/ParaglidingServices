using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ParaglidingServices.Api.Controllers;
using ParaglidingServices.Infrastructure.Models.Pilots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotsController : BaseController
    {
        private readonly IConfiguration _configuration;

        public PilotsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

/*        [HttpPost]
        public Task<ActionResult> Update([FromRoute] long pilotId, [FromBody] PilotCreateUpdateModel input)
        {
            return;
        }
*/
    }
}
