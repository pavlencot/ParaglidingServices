using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
