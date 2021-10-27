using AutoMapper;
using ParaglidingServices.Infrastructure.Models.Bookings;
using ParaglidingServices.Persistence.Data;
using ParaglidingServices.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Queries.Bookings
{
    public class GetBookingById : Query<long, BookingCreateModel>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookingById(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override async Task<BookingCreateModel> Dispatch(long input, CancellationToken cancellationToken = default)
        {
            var booking = await _dbContext.Bookings.SingleByIdOrDefaultAsync(input, cancellationToken);

            var result = _mapper.Map<BookingCreateModel>(booking);

            return result;
        }
    }
}
