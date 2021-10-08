using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Locations;
using ParaglidingServices.Persistence.Data;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Locations
{
    public class CreateLocationCommand : Command<LocationModel, Location>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateLocationCommand(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<Location> Dispatch(LocationModel input)
        {
            var location = _mapper.Map<Location>(input);

            await _dbContext.Locations.AddAsync(location);

            return location;
        }
    }
}
