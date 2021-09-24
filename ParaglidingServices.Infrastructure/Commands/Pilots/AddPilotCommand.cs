using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Pilots;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Pilots
{
    public class AddPilotCommand : Command<(long, PilotCreateUpdateModel), Pilot>
    {
        private readonly AppDbContext _dbContext;
        public AddPilotCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override async Task<Pilot> Dispatch((long, PilotCreateUpdateModel) input)
        {
            var (pilotId, model) = input;

            var pilot = new Pilot(model.Licence, model.Gender, model.Location);

            await _dbContext.Pilots.AddAsync(pilot);

            return pilot;
        }
    }
}
