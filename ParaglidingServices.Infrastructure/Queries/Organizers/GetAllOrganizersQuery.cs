using AutoMapper;
using ParaglidingServices.Infrastructure.Models.Organizers;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.Organizers
{
    public class GetAllOrganizersQuery : Query<AllOrganizersModel>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllOrganizersQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override Task<AllOrganizersModel> Dispatch(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /*        public override async Task<AllOrganizersModel> Dispatch(CancellationToken cancellationToken = default)
                {
                    var organizers = _dbContext.Organizers;

                    return await organizers;
                }*/
    }
}
