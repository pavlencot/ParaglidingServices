using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Pilots;
using ParaglidingServices.Persistence.Data;
using System;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Pilots
{
    public class CreatePilotCommand : Command<PilotCreateUpdateModel, Pilot>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreatePilotCommand(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override async Task<Pilot> Dispatch(PilotCreateUpdateModel input)
        {
            var pilot = _mapper.Map<Pilot>(input);

            await _dbContext.Pilots.AddAsync(pilot);

            return pilot;
        }
    }
}
