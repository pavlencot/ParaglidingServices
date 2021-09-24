using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Domain.Enums;

namespace ParaglidingServices.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string Country { get; set; }
        //something else
        public virtual IEnumerable<Competition> Competitions { get; set; }
        public virtual IEnumerable<Pilot> Pilots { get; set; }

        public Location()
        {

        }
    }
}
