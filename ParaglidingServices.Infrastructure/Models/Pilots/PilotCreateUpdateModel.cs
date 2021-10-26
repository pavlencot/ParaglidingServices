using System;

namespace ParaglidingServices.Infrastructure.Models.Pilots
{
    public class PilotCreateUpdateModel
    {
        //User
        /*        public string Email { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string UserName { get; set; }
                public string PhoneNumber { get; set; }
                public string Password { get; set; }
                public string ConfirmPassword { get; set; }
                public string Role { get; set; }*/
        //Pilot
        public long UserId {get; set;}
        public long LocationId { get; set; }

        public long LicenceNr { get; set; }
        public string Category { get; set; }
        public DateTimeOffset IssuedOn { get; set; }
        public DateTimeOffset ValidUntil { get; set; }
    }
}
