using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Pagination.Extensions;
using ParaglidingServices.Infrastructure.Models.Pagination.PagedRequestModel;
using ParaglidingServices.Infrastructure.Models.Pilots;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.Pilots
{
    public class GetPilotsPagedQuery : Query<PagedRequest, PaginatedResult<PilotModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPilotsPagedQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<PaginatedResult<PilotModel>> Dispatch(PagedRequest input, CancellationToken cancellationToken = default)
        {
            var competitionQuery = await _dbContext.Pilots.CreatePaginatedResultAsync<Pilot, PilotModel>(input, _mapper);

            return competitionQuery;
        }
    }
}
