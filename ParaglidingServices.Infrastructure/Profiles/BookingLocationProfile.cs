using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models;
using System;

namespace ParaglidingServices.Infrastructure.Profiles
{
    public class BookingLocationProfile : Profile
    {
        public BookingLocationProfile()
        {
            CreateMap<BookingLocationModel, BookingLocation>().ReverseMap();
        }
    }
}
