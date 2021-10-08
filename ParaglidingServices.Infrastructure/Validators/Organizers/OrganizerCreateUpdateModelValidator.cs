using System;
using FluentValidation;
using ParaglidingServices.Infrastructure.Models.Organizers;

namespace ParaglidingServices.Infrastructure.Validators.Organizers
{
    public class OrganizerCreateUpdateModelValidator : AbstractValidator<OrganizerCreateUpdateModel>
    {
        public OrganizerCreateUpdateModelValidator()
        {
            RuleFor(c => c.OrganizationCode).NotEmpty();
            RuleFor(n => n.Name).MaximumLength(100).NotEmpty();
            RuleFor(a => a.Adress).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty();
            RuleFor(d => d.Description).MaximumLength(500);
        }
    }
}
