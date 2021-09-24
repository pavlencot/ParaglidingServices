using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Domain.Entities
{
    public class FlightSchedule : BaseEntity
    {
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public DateTimeOffset Date { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

    }
}
