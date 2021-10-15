using ParaglidingServices.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace ParaglidingServices.Infrastructure.Models.Users
{
    public class ChangePasswordModel
    {
        [Required]
        [RegularExpression(AppConstants.Parameters.EmailRegex)]
        public string Email { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
