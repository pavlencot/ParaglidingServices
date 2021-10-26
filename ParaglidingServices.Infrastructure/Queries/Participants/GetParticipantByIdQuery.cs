using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParaglidingServices.Infrastructure.Models.Participants;
using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.Participants
{
    public class GetParticipantByIdQuery : Query<long, ParticipantModel>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetParticipantByIdQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ParticipantModel> Dispatch(long input, CancellationToken cancellationToken = default)
        {
            var participant = await _dbContext.Participants
                .AsNoTracking()
                .Include(x => x.Pilot.User)
                .Include(y => y.Pilot.Licence)
                .Include(z => z.Competition)
                .SingleByIdOrDefaultAsync(input, cancellationToken);

            var result = _mapper.Map<ParticipantModel>(participant);

            return result;
        }
    }
}
