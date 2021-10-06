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

        public override async Task Dispatch((long, PilotCreateUpdateModel) input)
        {
            var (pilotId, pilotModel) = input;

            var pilot = await _dbContext.Pilots.SingleByIdOrDefaultAsync(pilotId);

            _mapper.Map(pilotModel, pilot);

            _dbContext.Pilots.Update(pilot);
        }
    }
}
