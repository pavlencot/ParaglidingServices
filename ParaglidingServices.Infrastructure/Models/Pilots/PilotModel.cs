using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Models.Pilots
{
    public class PilotModel
    {
        public GenderId Gender { get; set; }

        public long LocationId { get; set; }
    }
}
