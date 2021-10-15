using System.ComponentModel.DataAnnotations;


namespace ParaglidingServices.Infrastructure.Models.Users
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
