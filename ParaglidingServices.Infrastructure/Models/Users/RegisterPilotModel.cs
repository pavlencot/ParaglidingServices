using ParaglidingServices.Infrastructure.Constants;
using ParaglidingServices.Infrastructure.Models.Pilots;
using System;
using System.ComponentModel.DataAnnotations;

namespace ParaglidingServices.Infrastructure.Models.Users
{
    public class RegisterPilotModel
    {
        public RegisterUserModel UserModel { get; set; }
        public PilotCreateUpdateModel PilotModel { get; set; }
    }
}
