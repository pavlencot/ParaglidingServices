using System;

namespace ParaglidingServices.Infrastructure.Models.Bookings
{
    public class BookingCreateModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTimeOffset Date { get; set; }
        public long BookingLocationId { get; set; }
        public long? PilotInstructorId { get; set; }
    }
}
