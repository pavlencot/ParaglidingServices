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

namespace ParaglidingServices.Infrastructure.Queries.Organizers
{
    public class GetOrganizerByIdQuery : Query<long, OrganizerModel>
    {
        private readonly AppDbContext _dbContext;

        public GetOrganizerByIdQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override async Task<OrganizerModel> Dispatch(long input, CancellationToken cancellationToken = default)
        {
            var org = await _dbContext.Organizers.SingleByIdOrDefaultAsync(input, cancellationToken);
            var organizer = await _dbContext.Organizers
                .Where(i => i.Id == input)
                .Select(o => OrganizerModel.From(o))
                .SingleOrDefaultAsync(cancellationToken);

            return organizer;    
        }
    }
}
