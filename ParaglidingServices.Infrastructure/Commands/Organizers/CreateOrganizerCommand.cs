using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Organizers;
using ParaglidingServices.Persistence.Data;
using AutoMapper;

namespace ParaglidingServices.Infrastructure.Commands.Organizers
{
    public class CreateOrganizerCommand : Command<OrganizerCreateUpdateModel, Organizer>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateOrganizerCommand(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<Organizer> Dispatch(OrganizerCreateUpdateModel input)
        {
            var organizer = _mapper.Map<Organizer>(input);

            await _dbContext.Organizers.AddAsync(organizer);

            return organizer;

        }
    }
}
