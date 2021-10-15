using ParaglidingServices.Infrastructure.Models.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.Bookings
{
    public class GetBookingById : Query<long, BookingCreateModel>
    {
        public override Task<BookingCreateModel> Dispatch(long input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
