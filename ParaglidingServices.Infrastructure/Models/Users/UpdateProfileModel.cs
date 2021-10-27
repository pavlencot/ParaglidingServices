using ParaglidingServices.Infrastructure.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace ParaglidingServices.Infrastructure.Models.Users
{
    public class UpdateProfileModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
