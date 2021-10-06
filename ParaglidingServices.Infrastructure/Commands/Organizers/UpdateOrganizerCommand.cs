using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Infrastructure.Models.Organizers;
using ParaglidingServices.Persistence.Extensions;
using AutoMapper;
using ParaglidingServices.Domain.Entities;

namespace ParaglidingServices.Infrastructure.Commands.Organizers
{
    public class UpdateOrganizerCommand : Command<(long, OrganizerCreateUpdateModel)>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateOrganizerCommand(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task Dispatch((long, OrganizerCreateUpdateModel) input)
        {
            var (orgId, orgModel) = input;

            var org = await _dbContext.Organizers.SingleByIdOrDefaultAsync(orgId);

            _mapper.Map(orgModel, org);

            _dbContext.Organizers.Update(org);
        }
    }
}
