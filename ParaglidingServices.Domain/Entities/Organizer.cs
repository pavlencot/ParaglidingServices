using System.Collections.Generic;

namespace ParaglidingServices.Domain.Entities
{
    public class Organizer : BaseEntity
    {
        public long OrganizationCode { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<CompetitionOrganizer> CompetitionOrganizer { get; set; }

        public Organizer()
        {
                
        }

        public Organizer(long code, string name, string adress, string phoneNumber, string description)
        {
            OrganizationCode = code;
            Name = name;
            Adress = adress;
            PhoneNumber = phoneNumber;
            Description = description;
            
        }
    }
}
