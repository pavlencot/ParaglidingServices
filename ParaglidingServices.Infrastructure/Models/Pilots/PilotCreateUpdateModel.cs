using ParaglidingServices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Models.Pilots
{
    public class PilotCreateUpdateModel
    {
        public Licence Licence { get; set; }
        public Gender Gender { get; set; }
        public Location Location { get; set; }

    }
}
