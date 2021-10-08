using System.Collections.Generic;

namespace ParaglidingServices.Domain.Entities
{
    public class Pilot : BaseEntity
    {
        public virtual Licence Licence { get; set; }
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual IEnumerable<Participant> Participants { get; set; }

        public Pilot()
        {

        }
    }
}
