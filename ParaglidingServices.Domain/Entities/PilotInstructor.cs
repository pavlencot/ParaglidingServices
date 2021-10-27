using System.Collections.Generic;

namespace ParaglidingServices.Domain.Entities
{
    public class PilotInstructor : Pilot
    {
        public virtual IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<FlightSchedule> FlightSchedules { get; set; }
    }
}
