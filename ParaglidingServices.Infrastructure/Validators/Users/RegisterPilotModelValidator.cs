using FluentValidation;
using ParaglidingServices.Infrastructure.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Validators.Users
{
    public class RegisterUserModelValidator : AbstractValidator<RegisterUserModel>
    {
        public RegisterUserModelValidator()
        {
            RuleFor(e => e.Email).EmailAddress().NotEmpty();
            RuleFor(f => f.FirstName).NotEmpty();
            RuleFor(l => l.LastName).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(c => c.ConfirmPassword).NotEmpty().Equal(p => p.Password);
            RuleFor(r => r.Role).NotEmpty();
        }
    }
}
