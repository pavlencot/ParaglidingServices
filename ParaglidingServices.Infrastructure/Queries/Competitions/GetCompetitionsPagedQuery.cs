using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Competitions;
using ParaglidingServices.Infrastructure.Models.Pagination.Extensions;
using ParaglidingServices.Infrastructure.Models.Pagination.PagedRequestModel;
using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.Competitions
{
    public class GetCompetitionsPagedQuery : Query<PagedRequest, PaginatedResult<CompetitionModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCompetitionsPagedQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<PaginatedResult<CompetitionModel>> Dispatch(PagedRequest input, CancellationToken cancellationToken = default)
        {
            var competitionQuery = await _dbContext.Competitions.CreatePaginatedResultAsync<Competition, CompetitionModel>(input, _mapper);

            return competitionQuery;
        }
    }
}
