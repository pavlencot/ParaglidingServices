using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingServices.Api.Controllers;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Commands.Pilots;
using ParaglidingServices.Infrastructure.Models.Pagination.PagedRequestModel;
using ParaglidingServices.Infrastructure.Models.Pilots;
using ParaglidingServices.Infrastructure.Queries.Pilots;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Controllers
{
    [Route("api/[controller]")]
    public class PilotsController : BaseController
    {
        [HttpPost]
        public Task<ActionResult<long>> Create([FromBody] PilotCreateUpdateModel input)
        {
            return ExecuteCommandReturningEntityId<CreatePilotCommand, PilotCreateUpdateModel, Pilot>(input);
        }

        [HttpGet("{pilotId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<PilotModel>> GetPilotById([FromRoute] long pilotId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetPilotByIdQuery, long, PilotModel>(pilotId, cancellationToken);
        }

        [HttpGet("get-paged")]
        public Task<ActionResult<PaginatedResult<PilotModel>>> GetPaginated([FromQuery] PagedRequest input, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetPilotsPagedQuery, PagedRequest, PaginatedResult<PilotModel>>(input, cancellationToken);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<IList<PilotModel>>> GetAllPilots(CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetAllPilotsQuery, IList<PilotModel>>(cancellationToken);
        }

        [HttpPut("{pilotId:long}")]
        public Task<ActionResult> Update([FromRoute] long pilotId, [FromBody] PilotCreateUpdateModel input)
        {
            return ExecuteCommand<UpdatePilotCommand, (long, PilotCreateUpdateModel)>((pilotId, input));
        }

        [HttpDelete("{pilotId:long}")]
        public Task<ActionResult> Delete([FromRoute] long pilotId)
        {
            return ExecuteCommand<DeletePilotCommand, long>(pilotId);
        }
    }
}
