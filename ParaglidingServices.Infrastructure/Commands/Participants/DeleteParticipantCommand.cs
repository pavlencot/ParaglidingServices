using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Participants
{
    public class DeleteParticipantCommand : Command<long>
    {
        private readonly AppDbContext _dbContext;

        public DeleteParticipantCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task Dispatch(long participantId)
        {
            var participant = await _dbContext.Participants.SingleByIdOrDefaultAsync(participantId);
            _dbContext.Participants.Remove(participant);
        }
    }
}
