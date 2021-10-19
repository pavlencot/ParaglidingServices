using AutoMapper;
using ParaglidingServices.Infrastructure.Models.Competitions;
using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Competitions
{
    public class UpdateCompetitionCommand : Command<(long, CompetitionModel)>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateCompetitionCommand(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task Dispatch((long, CompetitionModel) input)
        {
            var (competitionId, competitionModel) = input;

            var competition = await _dbContext.Pilots.SingleByIdOrDefaultAsync(competitionId);

            _mapper.Map(competitionModel, competition);

            _dbContext.Pilots.Update(competition);
        }
    }
}
