using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Commands.Organizers;
using ParaglidingServices.Infrastructure.Models.Organizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrganizersController : BaseController
    {
        [HttpPost("{organizerId:long}")]
        public Task<ActionResult<long>> Create([FromRoute] long organizerId, [FromBody] OrganizerCreateUpdateModel input)
        {
            return ExecuteCommandReturningEntityId<CreateOrganizerCommand, (long, OrganizerCreateUpdateModel), Organizer>((organizerId, input));
        }

        [HttpDelete("{organizerId:long}")]
        public Task<ActionResult> Delete([FromRoute] long organizerId)
        {
            return ExecuteCommand<DeleteOrganizerCommand, long>(organizerId);
        }
    }
}
