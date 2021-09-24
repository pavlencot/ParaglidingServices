using ParaglidingServices.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public long ClientId { get; set; }
        public virtual Client Client { get; set; }
        public DateTimeOffset Date { get; set; }
        public long BookingLocationId { get; set; }
        public virtual BookingLocation BookingLocation { get; set; }
        public long CouponId { get; set; }
        public virtual Coupon Coupon { get; set; }
        public long InstructorId { get; set; }
        public virtual PilotInstructor Instructor { get; set; }


        public Booking()
        {

        }
    }
}
