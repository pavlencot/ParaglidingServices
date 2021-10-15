using System;

namespace ParaglidingServices.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public DateTimeOffset Date { get; set; }
        public long BookingLocationId { get; set; }
        public virtual BookingLocation BookingLocation { get; set; }
        public long PilotInstructorId { get; set; }
        public virtual PilotInstructor PilotInstructor { get; set; }


        public Booking()
        {

        }
    }
}
