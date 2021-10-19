using AutoMapper;
using ParaglidingServices.Infrastructure.Models.Competitions;
using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.Competitions
{
    public class GetCompetitionByIdQuery : Query<long, CompetitionModel>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCompetitionByIdQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<CompetitionModel> Dispatch(long input, CancellationToken cancellationToken = default)
        {
            var competition = await _dbContext.Competitions.SingleByIdOrDefaultAsync(input, cancellationToken);

            var result = _mapper.Map<CompetitionModel>(competition);

            return result;
        }
    }
}
