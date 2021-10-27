using ParaglidingServices.Domain.Entities.Auth;
using System.Collections.Generic;

namespace ParaglidingServices.Domain.Entities
{
    public class Pilot : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public virtual Licence Licence { get; set; }
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual IEnumerable<Participant> Participants { get; set; }
    }
}
