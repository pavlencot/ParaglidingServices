using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Locations
{
    public class DeleteLocationCommand : Command<long>
    {
        private readonly AppDbContext _dbContext;

        public DeleteLocationCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task Dispatch(long locationId)
        {
            var location = await _dbContext.Locations.SingleByIdOrDefaultAsync(locationId);
            _dbContext.Locations.Remove(location);
        }
    }
}
