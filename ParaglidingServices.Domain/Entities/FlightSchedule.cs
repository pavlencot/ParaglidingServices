using System;

namespace ParaglidingServices.Domain.Entities
{
    public class FlightSchedule : BaseEntity
    {
        public DateTimeOffset Date { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public PilotInstructor PilotInstructor { get; set; }
    }
}
