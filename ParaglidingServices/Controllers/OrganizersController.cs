using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Commands.Organizers;
using ParaglidingServices.Infrastructure.Models.Organizers;
using ParaglidingServices.Infrastructure.Queries.Organizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrganizersController : BaseController
    {
        [HttpPost]
        public Task<ActionResult<long>> Create([FromBody] OrganizerCreateUpdateModel input)
        {
            return ExecuteCommandReturningEntityId<CreateOrganizerCommand, OrganizerCreateUpdateModel, long>(input);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<OrganizerModel>> GetById([FromRoute] long organizerId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetOrganizerByIdQuery, long, OrganizerModel>(organizerId, cancellationToken);
        }

        [HttpDelete("{organizerId:long}")]
        public Task<ActionResult> Delete([FromRoute] long organizerId)
        {
            return ExecuteCommand<DeleteOrganizerCommand, long>(organizerId);
        }
    }
}
