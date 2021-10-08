using System;

namespace ParaglidingServices.Domain.Entities
{
    public class FlightSchedule : BaseEntity
    {
        //want to remove time props
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public DateTimeOffset Date { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

    }
}
