using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Bookings
{
    public class DeleteBookingCommand : Command<long>
    {
        private readonly AppDbContext _dbContext;

        public DeleteBookingCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task Dispatch(long organizerId)
        {
            var organizer = await _dbContext.Organizers.SingleByIdOrDefaultAsync(organizerId);
            _dbContext.Organizers.Remove(organizer);
        }
    }
}
