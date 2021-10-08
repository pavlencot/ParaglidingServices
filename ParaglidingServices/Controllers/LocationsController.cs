using Microsoft.AspNetCore.Mvc;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Locations;
using System.Threading.Tasks;
using ParaglidingServices.Infrastructure.Commands.Locations;

namespace ParaglidingServices.Api.Controllers
{
    [Route("api/[controller]")]
    public class LocationsController : BaseController
    {
        [HttpPost]
        public Task<ActionResult<long>> Create([FromBody] LocationModel input)
        {
            return ExecuteCommandReturningEntityId<CreateLocationCommand, LocationModel, Location>(input);
        }

        [HttpDelete("{locationId:long}")]
        public Task<ActionResult> Delete([FromRoute] long locationId)
        {
            return ExecuteCommand<DeleteLocationCommand, long>(locationId);
        }
    }
}
