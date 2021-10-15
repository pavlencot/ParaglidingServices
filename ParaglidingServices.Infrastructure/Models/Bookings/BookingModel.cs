using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Models.Bookings
{
    public class BookingModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTimeOffset Date { get; set; }
        public string BookingLocation { get; set; }
        public long PilotInstructorId { get; set; }
    }
}
