using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Domain.Enums;
using ParaglidingServices.Infrastructure.Models.Pilots;

namespace ParaglidingServices.Infrastructure.Validators.Pilots
{
    public class PilotCreateUpdateModelValidator : AbstractValidator<PilotCreateUpdateModel>
    {
        public PilotCreateUpdateModelValidator()
        {
            RuleFor(n => n.Name).MaximumLength(75).NotEmpty();
            RuleFor(c => c.Country).MaximumLength(50).NotEmpty();
/*            RuleFor(g => (long)g.PilotGender)
                  .GreaterThanOrEqualTo((long)Enum.GetValues(typeof(GenderId)).Cast<GenderId>().Min())
                  .LessThanOrEqualTo((long)Enum.GetValues(typeof(GenderId)).Cast<GenderId>().Max())
                  .When(x => x.PilotGender != null && x.PilotGender > 0);*/

            //RuleFor(l => l.LicenceId).NotEmpty();
        }
    }
}
