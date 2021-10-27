using System.Collections.Generic;

namespace ParaglidingServices.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string Country { get; set; }
        public virtual IEnumerable<Competition> Competitions { get; set; }
        public virtual IEnumerable<Pilot> Pilots { get; set; }
    }
}
