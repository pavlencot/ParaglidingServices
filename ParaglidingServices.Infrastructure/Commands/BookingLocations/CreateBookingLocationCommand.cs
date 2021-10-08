using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models;
using ParaglidingServices.Persistence.Data;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.BookingLocations
{
    public class CreateBookingLocationCommand : Command<BookingLocationModel, BookingLocation>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookingLocationCommand(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override async Task<BookingLocation> Dispatch(BookingLocationModel input)
        {
            var bookingLocation = _mapper.Map<BookingLocation>(input);

            await _dbContext.BookingLocations.AddAsync(bookingLocation);

            return bookingLocation;
        }
    }
}
