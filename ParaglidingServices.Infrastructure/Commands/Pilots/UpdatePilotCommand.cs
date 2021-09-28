using ParaglidingServices.Infrastructure.Models.Pilots;
using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Pilots
{
    public class UpdatePilotCommand : Command<(long, PilotCreateUpdateModel)>
    {
        private readonly AppDbContext _dbContext;
        public override async Task Dispatch((long, PilotCreateUpdateModel) input)
        {
            var (pilotId, model) = input;

            var pilot = await _dbContext.Pilots.SingleByIdOrDefaultAsync(pilotId);

         /*   pilot.Licence = model.LicenceId;
            pilot.Location = model.Location;*/
        }
    }
}
