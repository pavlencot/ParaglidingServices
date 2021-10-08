using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Commands.BookingLocations;
using ParaglidingServices.Infrastructure.Models;
using ParaglidingServices.Infrastructure.Queries.BookingLocations;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Controllers
{
    [Route("api/[controller]")]
    public class BookingLocationsController : BaseController
    {
        [HttpPost]
        public Task<ActionResult<long>> Create([FromBody] BookingLocationModel input)
        {
            return ExecuteCommandReturningEntityId<CreateBookingLocationCommand, BookingLocationModel, BookingLocation>(input);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<BookingLocationModel>> GetAllBookingLocation(CancellationToken cancellationToken)
        {
            return ExecuteQuery<GetAllBookingLocationsQuery, BookingLocationModel>(cancellationToken);
        }

        [HttpDelete("{bookingLocationId:long}")]
        public Task<ActionResult> Delete([FromRoute] long bookingLocationId)
        {
            return ExecuteCommand<DeleteBookingLocationCommand, long>(bookingLocationId);
        }
    }
}
