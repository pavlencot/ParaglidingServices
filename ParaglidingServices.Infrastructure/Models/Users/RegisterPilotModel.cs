using ParaglidingServices.Infrastructure.Constants;
using ParaglidingServices.Infrastructure.Models.Pilots;
using System;
using System.ComponentModel.DataAnnotations;

namespace ParaglidingServices.Infrastructure.Models.Users
{
    public class RegisterPilotModel
    {
        public RegisterUserModel UserModel { get; set; }
/*        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }*/
        public PilotCreateUpdateModel PilotModel { get; set; }
/*        public long LocationId { get; set; }

        public long LicenceNr { get; set; }
        public string Category { get; set; }
        public DateTimeOffset IssuedOn { get; set; }
        public DateTimeOffset ValidUntil { get; set; }*/
    }
}
