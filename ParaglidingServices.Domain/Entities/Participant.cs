namespace ParaglidingServices.Domain.Entities
{
    public class Participant : BaseEntity
    {
        public long PilotId { get; set; }
        public virtual Pilot Pilot { get; set; }
      
        public long CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }
    }
}
