﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Domain.Enums;

namespace ParaglidingServices.Domain.Entities
{
    public class Organizer : BaseEntity
    {
        public long OrganizationCode { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CompetitionOrganizer> CompetitionOrganizer { get; set; }

        public Organizer()
        {

        }
    }
}