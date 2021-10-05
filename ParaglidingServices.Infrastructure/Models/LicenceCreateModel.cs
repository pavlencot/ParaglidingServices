using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Models
{
    public class LicenceCreateModel
    {
        public long PilotId { get; set; }
        public long LicenceNr { get; set; }
        public string Category { get; set; }

    }
}
