using AutoMapper;
using ParaglidingServices.Infrastructure.Models;
using ParaglidingServices.Persistence.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.BookingLocations
{
    public class GetAllBookingLocationsQuery : Query<BookingLocationModel>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllBookingLocationsQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override Task<BookingLocationModel> Dispatch(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
