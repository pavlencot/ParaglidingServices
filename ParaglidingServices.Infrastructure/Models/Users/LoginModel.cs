using ParaglidingServices.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;


namespace ParaglidingServices.Infrastructure.Models.Users
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
