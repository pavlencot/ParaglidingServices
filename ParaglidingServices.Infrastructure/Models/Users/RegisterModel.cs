using ParaglidingServices.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace ParaglidingServices.Infrastructure.Models.Users
{
    public class RegisterModel
    {
        [Required]
        [RegularExpression(AppConstants.Parameters.EmailRegex)]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}
