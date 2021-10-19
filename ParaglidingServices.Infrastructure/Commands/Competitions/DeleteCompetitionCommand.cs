using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Competitions
{
    public class DeleteCompetitionCommand : Command<long>
    {
        private readonly AppDbContext _dbContext;

        public DeleteCompetitionCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task Dispatch(long competitionId)
        {
            var competition = await _dbContext.Competitions.SingleByIdOrDefaultAsync(competitionId);
            _dbContext.Competitions.Remove(competition);
        }
    }
}
