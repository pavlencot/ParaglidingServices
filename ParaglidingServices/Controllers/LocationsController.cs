using Microsoft.AspNetCore.Mvc;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Locations;
using System.Threading.Tasks;
using ParaglidingServices.Infrastructure.Commands.Locations;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using ParaglidingServices.Infrastructure.Queries.Locations;

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<IList<LocationModel>>> GetAllBookingLocation(CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetAllLocationsQuery, IList<LocationModel>>(cancellationToken);
        }

        [HttpDelete("{locationId:long}")]
        public Task<ActionResult> Delete([FromRoute] long locationId)
        {
            return ExecuteCommand<DeleteLocationCommand, long>(locationId);
        }
    }
}
