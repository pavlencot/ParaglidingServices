using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Models.Instructors
{
    public class InstructorModel
    {
        public long Id {get; set;}
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Country { get; set; }

        public long LicenceNr { get; set; }
        public string Category { get; set; }
        public DateTimeOffset IssuedOn { get; set; }
        public DateTimeOffset ValidUntil { get; set; }
        public string Discriminator { get; }

    }
}
