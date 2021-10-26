using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParaglidingServices.Infrastructure.Models.Locations;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.Locations
{
    public class GetAllLocationsQuery : Query<IList<LocationModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllLocationsQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<IList<LocationModel>> Dispatch(CancellationToken cancellationToken = default)
        {
            var locations = await _dbContext.Locations.ToListAsync();
            return _mapper.Map<IList<LocationModel>>(locations);
        }
    }
}
