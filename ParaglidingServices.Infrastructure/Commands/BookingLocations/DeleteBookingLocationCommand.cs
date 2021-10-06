using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.BookingLocations
{
    public class DeleteBookingLocationCommand : Command<long>
    {
        private readonly AppDbContext _dbContext;

        public DeleteBookingLocationCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override async Task Dispatch(long bookingLocationId)
        {
            var bookingLocation = await _dbContext.BookingLocations.SingleByIdOrDefaultAsync(bookingLocationId);
            _dbContext.BookingLocations.Remove(bookingLocation);
        }
    }
}
