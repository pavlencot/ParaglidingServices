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

namespace ParaglidingServices.Infrastructure.Commands.Organizers
{
    public class CreateOrganizerCommand : Command<(long, OrganizerCreateUpdateModel), Organizer>
    {
        private readonly HttpContext _httpContext;
        private readonly AppDbContext _dbContext;

        public CreateOrganizerCommand(IHttpContextAccessor accessor, AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _httpContext = accessor.HttpContext;
        }

        public override async Task<Organizer> Dispatch((long, OrganizerCreateUpdateModel) input)
        {
            var (organizerId, organizerModel) = input;

            var organizer = new Organizer();

            await _dbContext.Organizers.AddAsync(organizer);

            return organizer;

        }
    }
}
