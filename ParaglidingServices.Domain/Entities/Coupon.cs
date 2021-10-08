using System;

namespace ParaglidingServices.Domain.Entities
{
    public class Coupon : BaseEntity
    {
        public Guid Code { get; set; }
        public virtual Booking Booking { get; set; }
        public bool IsApplied { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
