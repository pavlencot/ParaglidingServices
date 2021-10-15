using System;
using System.Threading.Tasks;
using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Bookings;
using ParaglidingServices.Persistence.Data;

namespace ParaglidingServices.Infrastructure.Commands.Bookings
{
    public class CreateBookingCommand : Command<BookingCreateModel, Booking>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;


        public CreateBookingCommand(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override async Task<Booking> Dispatch(BookingCreateModel input)
        {
            var booking = _mapper.Map<Booking>(input);

            await _dbContext.Bookings.AddAsync(booking);

            return booking;
        }
    }
}
