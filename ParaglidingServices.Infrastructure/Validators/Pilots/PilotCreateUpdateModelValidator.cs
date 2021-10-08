using FluentValidation;
using ParaglidingServices.Infrastructure.Models.Pilots;

namespace ParaglidingServices.Infrastructure.Validators.Pilots
{
    public class PilotCreateUpdateModelValidator : AbstractValidator<PilotCreateUpdateModel>
    {
        public PilotCreateUpdateModelValidator()
        {
        }
    }
}
