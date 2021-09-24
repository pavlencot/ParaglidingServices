using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Domain.Enums;

namespace ParaglidingServices.Domain.Entities
{
    public class Competition : BaseEntity
    {
        public string CompetitionCode { get; set; }
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<CompetitionOrganizer> CompetitionOrganizers { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }

        public Competition()
        {

        }
    }
}
