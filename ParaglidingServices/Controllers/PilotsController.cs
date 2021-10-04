using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ParaglidingServices.Api.Controllers;
using ParaglidingServices.Infrastructure.Commands.Pilots;
using ParaglidingServices.Infrastructure.Models.Pilots;
using ParaglidingServices.Infrastructure.Queries.Pilots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotsController : BaseController
    {
        [HttpPost]
        public Task<ActionResult<long>> Create([FromBody] PilotCreateUpdateModel input)
        {
            return ExecuteCommandReturningEntityId<CreatePilotCommand, PilotCreateUpdateModel, long>(input);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<PilotModel>> GetById([FromRoute] long organizerId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetPilotByIdQuery, long, PilotModel>(organizerId, cancellationToken);
        }

        [HttpPut]
        public Task<ActionResult> Update([FromRoute] long organizerId, [FromBody] PilotCreateUpdateModel input)
        {
            return ExecuteCommand<UpdatePilotCommand, (long, PilotCreateUpdateModel)>((organizerId, input));
        }

        [HttpDelete("{pilotId:long}")]
        public Task<ActionResult> Delete([FromRoute] long organizerId)
        {
            return ExecuteCommand<DeletePilotCommand, long>(organizerId);
        }
    }
}
