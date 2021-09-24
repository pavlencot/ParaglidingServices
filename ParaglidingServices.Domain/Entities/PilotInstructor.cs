using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Domain.Enums;

namespace ParaglidingServices.Domain.Entities
{
    public class PilotInstructor : Pilot
    {
        public virtual IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<FlightSchedule> FlightSchedules { get; set; }
        
        public PilotInstructor()
        {

        }
    }
}
