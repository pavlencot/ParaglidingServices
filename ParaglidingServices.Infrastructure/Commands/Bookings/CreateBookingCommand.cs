using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Bookings;
using Microsoft.EntityFrameworkCore;
using ParaglidingServices.Persistence.Data;

namespace ParaglidingServices.Infrastructure.Commands.Bookings
{
    public class CreateBookingCommand : Command<(long, BookingCreateModel), Booking>
    {
        private readonly AppDbContext _dbContext;

        public CreateBookingCommand(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override Task<Booking> Dispatch((long, BookingCreateModel) input)
        {
            throw new NotImplementedException();
        }
    }
}
