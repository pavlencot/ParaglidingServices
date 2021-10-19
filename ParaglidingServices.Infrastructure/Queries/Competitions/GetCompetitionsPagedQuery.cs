using AutoMapper;
using ParaglidingServices.Infrastructure.Models.Competitions;
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
    public class GetCompetitionsPagedQuery : Query<PagedRequest, PagedResult<CompetitionModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCompetitionsPagedQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override Task<PagedResult<CompetitionModel>> Dispatch(PagedRequest input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
