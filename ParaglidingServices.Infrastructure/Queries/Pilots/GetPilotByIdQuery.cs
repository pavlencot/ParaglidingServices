using AutoMapper;
using ParaglidingServices.Persistence.Data;
using System;
using System.Threading;
using System.Threading.Tasks;
using ParaglidingServices.Infrastructure.Models.Pilots;
using ParaglidingServices.Persistence.Extensions;

namespace ParaglidingServices.Infrastructure.Queries.Pilots
{
    public class GetPilotByIdQuery : Query<long, PilotModel>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPilotByIdQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<PilotModel> Dispatch(long input, CancellationToken cancellationToken = default)
        {
            var pilot = await _dbContext.Pilots.SingleByIdOrDefaultAsync(input, cancellationToken);

            var result = _mapper.Map<PilotModel>(pilot);

            return result;
        }
    }
}
