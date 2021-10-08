using System;

namespace ParaglidingServices.Infrastructure.Models.Pilots
{
    public class PilotCreateUpdateModel
    {
        public long LocationId { get; set; }

        public long LicenceNr { get; set; }
        public string Category { get; set; }
        public DateTimeOffset IssuedOn { get; set; }
        public DateTimeOffset ValidUntil { get; set; }
    }
}
