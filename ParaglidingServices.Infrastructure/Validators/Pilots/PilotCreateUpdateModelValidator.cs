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
            RuleFor(g => g.Gender).IsInEnum();

            //RuleFor(l => l.LicenceId).NotEmpty();
        }
    }
}
