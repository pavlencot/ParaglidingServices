using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Domain.Enums;

namespace ParaglidingServices.Domain.Entities
{
    public class Licence : BaseEntity
    {
        public long PilotId { get; set; }
        public virtual Pilot Pilot { get; set; }
        public long LicenceNr { get; set; }
        public string Category { get; set; }
        public DateTimeOffset IssuedOn { get; set; }
        public DateTimeOffset ValidUntil { get; set; }

        public Licence()
        {

        }
    }
}
