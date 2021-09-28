using ParaglidingServices.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Domain.Entities
{
    public class Pilot : BaseEntity
    {
        public virtual Licence Licence { get; set; }
        public Gender Gender { get; set; }
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual List<Participant> Participants { get; set; }

        public Pilot()
        {

        }

/*        public Pilot(Licence licence, Gender gender, Location location)
        {
            Licence = licence;
            Gender = gender;
            Location = location;
        }*/
    }
}
