using System;
using System.Threading.Tasks;
using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;

namespace ParaglidingServices.Infrastructure.Commands.Organizers
{
    public class DeleteOrganizerCommand : Command<long>
    {
        private readonly AppDbContext _dbContext;

        public DeleteOrganizerCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task Dispatch(long organizerId)
        {
            var organizer = await _dbContext.Organizers.SingleByIdOrDefaultAsync(organizerId);
            _dbContext.Organizers.Remove(organizer);
        }
    }
}
