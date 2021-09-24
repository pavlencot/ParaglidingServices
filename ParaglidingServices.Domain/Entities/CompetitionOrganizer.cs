using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Domain.Entities
{
    public class CompetitionOrganizer : BaseEntity
    {
        public long CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }
        public long OrganizerId { get; set; }
        public virtual Organizer Organizer { get; set; } 
    }
}
