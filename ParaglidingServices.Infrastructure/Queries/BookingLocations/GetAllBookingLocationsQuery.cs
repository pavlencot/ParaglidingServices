using ParaglidingServices.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.BookingLocations
{
    public class GetAllBookingLocationsQuery : Query<BookingLocationModel>
    {
        public override Task<BookingLocationModel> Dispatch(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
