using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParaglidingServices.Infrastructure.Models.Pilots;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.Pilots
{
    public class GetAllPilotsQuery : Query<IList<PilotModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllPilotsQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<IList<PilotModel>> Dispatch(CancellationToken cancellationToken = default)
        {
            var pilots = await _dbContext.Pilots
                .AsNoTracking()
                .Include(u => u.User)
                .Include(x => x.Licence)
                .Include(y => y.Location)
                .ToListAsync();
            return _mapper.Map<IList<PilotModel>>(pilots);
        }
    }
}
