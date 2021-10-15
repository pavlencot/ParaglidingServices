using ParaglidingServices.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Infrastructure.Models.Bookings;

namespace ParaglidingServices.Infrastructure.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingModel>()
                .ForMember(b => b.BookingLocation, m => m.MapFrom(c => c.BookingLocation.StartLocation));
            CreateMap<BookingCreateModel, Booking>().ReverseMap();
        }
        
    }
}
