using ParaglidingServices.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;


namespace ParaglidingServices.Infrastructure.Models.Users
{
    public class LoginModel
    {
        [Required]
        [RegularExpression(AppConstants.Parameters.EmailRegex)]

        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
