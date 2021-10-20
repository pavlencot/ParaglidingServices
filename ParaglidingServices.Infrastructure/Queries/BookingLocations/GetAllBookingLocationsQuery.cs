using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParaglidingServices.Infrastructure.Models;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.BookingLocations
{
    public class GetAllBookingLocationsQuery : Query<IList<BookingLocationModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllBookingLocationsQuery(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<IList<BookingLocationModel>> Dispatch(CancellationToken cancellationToken = default)
        {
            var locations = await _dbContext.BookingLocations.ToListAsync();
            return _mapper.Map<IList<BookingLocationModel>>(locations);
        }
    }
}
