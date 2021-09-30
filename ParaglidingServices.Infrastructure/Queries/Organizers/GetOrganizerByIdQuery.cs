using Microsoft.EntityFrameworkCore;
using ParaglidingServices.Infrastructure.Models.Organizers;
using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ParaglidingServices.Domain.Entities;

namespace ParaglidingServices.Infrastructure.Queries.Organizers
{
    public class GetOrganizerByIdQuery : Query<long, OrganizerModel>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrganizerByIdQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<OrganizerModel> Dispatch(long input, CancellationToken cancellationToken = default)
        {
            var org = await _dbContext.Organizers.SingleByIdOrDefaultAsync(input, cancellationToken);

            var result = _mapper.Map<OrganizerModel>(org);

            return result;
        }
    }
}
