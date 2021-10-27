using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Commands.Participants;
using ParaglidingServices.Infrastructure.Models.Pagination.PagedRequestModel;
using ParaglidingServices.Infrastructure.Models.Participants;
using ParaglidingServices.Infrastructure.Queries.Participants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Controllers
{
    [Route("api/[controller]")]
    public class ParticipantsController : BaseController
    {
        [HttpPost]
        public Task<ActionResult<long>> Create([FromBody] ParticipantCreateModel input)
        {
            return ExecuteCommandReturningEntityId<CreateParticipantCommand, ParticipantCreateModel, Participant>(input);
        }

        [HttpGet("{participantId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<ParticipantModel>> GetParticipantById([FromRoute] long participantId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetParticipantByIdQuery, long, ParticipantModel>(participantId, cancellationToken);
        }

        [HttpGet("get-paged")]
        public Task<ActionResult<PaginatedResult<ParticipantModel>>> GetPaginated([FromQuery] PagedRequest input, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetParticipantsPagedQuery, PagedRequest, PaginatedResult<ParticipantModel>>(input, cancellationToken);
        }

        [HttpDelete("{participantId:long}")]
        public Task<ActionResult> Delete([FromRoute] long pilotId)
        {
            return ExecuteCommand<DeleteParticipantCommand, long>(pilotId);
        }
    }
}
