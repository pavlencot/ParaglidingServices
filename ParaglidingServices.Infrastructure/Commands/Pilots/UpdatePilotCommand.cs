using AutoMapper;
using ParaglidingServices.Domain.Entities;
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
        private readonly IMapper _mapper;

        public UpdatePilotCommand(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<Pilot> Dispatch((long, PilotCreateUpdateModel) input)
        {
            //var (pilotId, model) = input;
            var pilot = _mapper.Map<Pilot>(input); 

            await _dbContext.Pilots.SingleByIdOrDefaultAsync(input.Item1);

            return pilot;
        }
    }
}
