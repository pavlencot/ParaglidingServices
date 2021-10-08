using System;

namespace ParaglidingServices.Infrastructure.Models.Organizers
{
    public class OrganizerCreateUpdateModel
    {
        public long OrganizationCode { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
    }
}
