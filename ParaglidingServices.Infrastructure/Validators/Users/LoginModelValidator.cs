using FluentValidation;
using ParaglidingServices.Infrastructure.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Validators.Users
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(u => u.Login).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
