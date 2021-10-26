using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Commands.Instructors;
using ParaglidingServices.Infrastructure.Models.Instructors;
using ParaglidingServices.Infrastructure.Queries.Instructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotInstructorsController : BaseController
    {
        [HttpPost]
        public Task<ActionResult<long>> Create([FromBody] InstructorCreateUpdateModel input)
        {
            return ExecuteCommandReturningEntityId<CreateInstructorCommand, InstructorCreateUpdateModel, PilotInstructor>(input);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ActionResult<IList<InstructorModel>>> GetAllInstructors(CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetAllInstructorsQuery, IList<InstructorModel>>(cancellationToken);
        }
    }
}
