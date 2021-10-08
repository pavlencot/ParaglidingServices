using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Pilots
{
    public class DeletePilotCommand : Command<long>
    {
        private readonly AppDbContext _dbContext;

        public DeletePilotCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task Dispatch(long pilotId)
        {
            var pilot = await _dbContext.Pilots.SingleByIdOrDefaultAsync(pilotId);
            _dbContext.Pilots.Remove(pilot);
        }
    }
}
