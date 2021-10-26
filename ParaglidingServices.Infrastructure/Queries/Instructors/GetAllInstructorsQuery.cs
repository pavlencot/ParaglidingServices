using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParaglidingServices.Infrastructure.Models.Instructors;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.Instructors
{
    public class GetAllInstructorsQuery : Query<IList<InstructorModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllInstructorsQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public override async Task<IList<InstructorModel>> Dispatch(CancellationToken cancellationToken = default)
        {
            var instructors = await _dbContext.PilotInstructors
                .AsNoTracking()
                .Include(u => u.User)
                .Include(x => x.Licence)
                .Include(y => y.Location)
                .ToListAsync();
            return _mapper.Map<IList<InstructorModel>>(instructors);
        }
    }
}
