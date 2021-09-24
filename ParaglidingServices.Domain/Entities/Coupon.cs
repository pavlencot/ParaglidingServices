using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Domain.Enums;

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
