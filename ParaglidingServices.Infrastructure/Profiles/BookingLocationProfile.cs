using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
