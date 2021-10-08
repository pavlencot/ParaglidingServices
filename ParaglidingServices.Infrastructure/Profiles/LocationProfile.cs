using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Locations;
using System;
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
