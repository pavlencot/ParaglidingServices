using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Infrastructure.Models.Organizers;
using ParaglidingServices.Persistence.Extensions;

namespace ParaglidingServices.Infrastructure.Commands.Organizers
{
    public class UpdateOrganizerCommand : Command<(long, OrganizerCreateUpdateModel)>
    {
        private readonly AppDbContext _dbContext;

        public UpdateOrganizerCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task Dispatch((long, OrganizerCreateUpdateModel) input)
        {
            var (organizerId, organizerModel) = input;
            var organizer = await _dbContext.Organizers.SingleByIdOrDefaultAsync(organizerId);

            organizer.Name = organizerModel.Name;
            organizer.PhoneNumber = organizerModel.PhoneNumber;
            organizer.Adress = organizerModel.Adress;
            organizer.Description = organizerModel.Description;
        }

    }
}
