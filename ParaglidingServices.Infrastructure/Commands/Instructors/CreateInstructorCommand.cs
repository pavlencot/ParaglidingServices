using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Instructors;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Instructors
{
    public class CreateInstructorCommand : Command<InstructorCreateUpdateModel, PilotInstructor>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateInstructorCommand(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override async Task<PilotInstructor> Dispatch(InstructorCreateUpdateModel input)
        {
            var pilot = _mapper.Map<PilotInstructor>(input);

            await _dbContext.Pilots.AddAsync(pilot);

            return pilot;
        }
    }
}
