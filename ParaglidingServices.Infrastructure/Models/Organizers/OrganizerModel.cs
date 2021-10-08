using System;

namespace ParaglidingServices.Infrastructure.Models.Organizers
{
    public class OrganizerModel
    {
        public long Id { get; set; }
        public long OrganizationCode { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
    }
}
