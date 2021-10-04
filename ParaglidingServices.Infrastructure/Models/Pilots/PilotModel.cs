using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Models.Pilots
{
    public class PilotModel
    {
        public long Id { get; set; }
        public long LicenceNr { get; set; }
        public string LicenceCategory { get; set; }

    }
}
