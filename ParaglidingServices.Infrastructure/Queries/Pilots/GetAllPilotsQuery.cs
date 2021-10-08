using AutoMapper;
using ParaglidingServices.Infrastructure.Models.Pilots;
using ParaglidingServices.Persistence.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.Pilots
{
    public class GetAllPilotsQuery : Query<PilotModel>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllPilotsQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override Task<PilotModel> Dispatch(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
