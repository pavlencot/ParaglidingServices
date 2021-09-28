using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Infrastructure;
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
