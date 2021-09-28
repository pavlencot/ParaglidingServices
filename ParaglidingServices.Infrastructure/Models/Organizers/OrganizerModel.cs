using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Domain.Enums;

namespace ParaglidingServices.Infrastructure.Models.Organizers
{
    public class OrganizerModel
    {
        public long Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        //public string LogoPath { get; set; }

        public static OrganizerModel From(Organizer src) => new()
        {
            Id = src.Id,
            Code = src.OrganizationCode,
            Name = src.Name,
            Adress = src.Adress,
            PhoneNumber = src.PhoneNumber,
            Description = src.Description
            //LogoPath = src.LogoPath
        };
    }
}
