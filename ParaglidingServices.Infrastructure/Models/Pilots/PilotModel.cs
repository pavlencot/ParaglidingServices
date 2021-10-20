using System;

namespace ParaglidingServices.Infrastructure.Models.Pilots
{
    public class PilotModel
    {
        public long Id { get; set; }
        public string Country { get; set; }
        public long LicenceNr { get; set; }
        public string Category { get; set; }
    }
}
