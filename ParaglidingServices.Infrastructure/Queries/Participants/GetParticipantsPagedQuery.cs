using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Pagination.Extensions;
using ParaglidingServices.Infrastructure.Models.Pagination.PagedRequestModel;
using ParaglidingServices.Infrastructure.Models.Participants;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.Participants
{
    public class GetParticipantsPagedQuery : Query<PagedRequest, PaginatedResult<ParticipantModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetParticipantsPagedQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<PaginatedResult<ParticipantModel>> Dispatch(PagedRequest input, CancellationToken cancellationToken = default)
        {
            var participantQuery = await _dbContext.Participants.CreatePaginatedResultAsync<Participant, ParticipantModel>(input, _mapper);

            return participantQuery;
        }
    }
}
