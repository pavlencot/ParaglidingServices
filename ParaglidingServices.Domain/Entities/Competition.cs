using System.Collections.Generic;
using System;

namespace ParaglidingServices.Domain.Entities
{
    public class Competition : BaseEntity
    {
        public string CompetitionCode { get; set; }
        public string CompetitionName { get; set; }
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
        public DateTimeOffset PeriodFrom { get; set; }
        public DateTimeOffset PeriodTo { get; set; }

        public virtual ICollection<CompetitionOrganizer> CompetitionOrganizers { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
