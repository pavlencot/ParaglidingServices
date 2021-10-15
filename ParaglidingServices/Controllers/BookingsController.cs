using Microsoft.AspNetCore.Mvc;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Commands.Bookings;
using ParaglidingServices.Infrastructure.Models.Bookings;

using System.Threading.Tasks;

namespace ParaglidingServices.Api.Controllers
{
    [Route("api/[controller]")]
    public class BookingsController : BaseController
    {
        [HttpPost]
        public Task<ActionResult<long>> Create([FromBody] BookingCreateModel input)
        {
            return ExecuteCommandReturningEntityId<CreateBookingCommand, BookingCreateModel, Booking>(input);
        }

        [HttpDelete("{bookingId:long}")]
        public Task<ActionResult> Delete([FromRoute] long bookingId)
        {
            return ExecuteCommand<DeleteBookingCommand, long>(bookingId);
        }
    }
}
