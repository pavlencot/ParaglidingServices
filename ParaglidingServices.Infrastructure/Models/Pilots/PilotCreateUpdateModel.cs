using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Models.Pilots
{
    public class PilotCreateUpdateModel
    {
        public string Name { get; set; }
 
        public GenderId Gender { get; set; }


    }
}
