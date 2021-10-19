using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Competitions;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Competitions
{
    public class CreateCompetitionCommand : Command<CompetitionModel, Competition>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;


        public CreateCompetitionCommand(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override async Task<Competition> Dispatch(CompetitionModel input)
        {
            var competition = _mapper.Map<Competition>(input);

            await _dbContext.Competitions.AddAsync(competition);

            return competition;
        }
    }
}
