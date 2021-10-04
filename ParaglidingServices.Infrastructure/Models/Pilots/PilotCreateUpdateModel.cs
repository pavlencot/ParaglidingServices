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
        public string Name { get; set; }
        public string Country { get; set; } //enum?
        public Gender PilotGender { get; set; }
        public long LicenceNr { get; set; }
        public string LicenceCategory { get; set; }
        public DateTimeOffset IssuedOn { get; set; }
        public DateTimeOffset ValidUntil { get; set; }

    }
}
