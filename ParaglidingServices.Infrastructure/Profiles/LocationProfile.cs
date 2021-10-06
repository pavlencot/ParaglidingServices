using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ParaglidingServices.Infrastructure.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationModel>().ReverseMap();
        }
    }
}
