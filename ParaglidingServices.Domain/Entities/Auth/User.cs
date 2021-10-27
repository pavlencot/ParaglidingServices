using Microsoft.AspNetCore.Identity;
using System;

namespace ParaglidingServices.Domain.Entities.Auth
{
    public class User : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Pilot Pilot { get; set; }
        public Organizer Organizer { get; set; }
    }
}
