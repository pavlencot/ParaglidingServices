
using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Participants;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Participants
{
    public class CreateParticipantCommand : Command<ParticipantCreateModel, Participant>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateParticipantCommand(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override async Task<Participant> Dispatch(ParticipantCreateModel input)
        {
            var participant = _mapper.Map<Participant>(input);

            await _dbContext.Participants.AddAsync(participant);

            return participant;
        }
    }
}
