using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Commands.Competitions;
using ParaglidingServices.Infrastructure.Models.Competitions;
using ParaglidingServices.Infrastructure.Queries.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Controllers
{
    [Route("api/[controller]")]
    public class CompetitionsController : BaseController
    {
        [HttpPost]
        public Task<ActionResult<long>> Create([FromBody] CompetitionModel input)
        {
            return ExecuteCommandReturningEntityId<CreateCompetitionCommand, CompetitionModel, Competition>(input);
        }

        [HttpGet("{competitionId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<CompetitionModel>> GetById([FromRoute] long competitionId, CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetCompetitionByIdQuery, long, CompetitionModel>(competitionId, cancellationToken);
        }

        [HttpPut("{competitionId:long}")]
        public Task<ActionResult> Update([FromRoute] long competitionId, [FromBody] CompetitionModel input)
        {
            return ExecuteCommand<UpdateCompetitionCommand, (long, CompetitionModel)>((competitionId, input));
        }

        [HttpDelete("{competitionId:long}")]
        public Task<ActionResult> Delete([FromRoute] long competitionId)
        {
            return ExecuteCommand<DeleteCompetitionCommand, long>(competitionId);
        }
    }
}
