using ParaglidingServices.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace ParaglidingServices.Infrastructure.Models.Users
{
    public class ChangePasswordModel
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
