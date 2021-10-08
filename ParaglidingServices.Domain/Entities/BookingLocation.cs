using System.Collections.Generic;

namespace ParaglidingServices.Domain.Entities
{
    public class BookingLocation : BaseEntity
    {
        public string StartLocation { get; set; }
        public virtual IEnumerable<Booking> Bookings { get; set; }

        public BookingLocation()
        {

        }
    }
}
