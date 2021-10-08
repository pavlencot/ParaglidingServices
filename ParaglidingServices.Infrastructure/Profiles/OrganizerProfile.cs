using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Organizers;
using System;

namespace ParaglidingServices.Infrastructure.Profiles
{
    public class OrganizerProfile : Profile
    {
        public OrganizerProfile()
        {
            CreateMap<Organizer, OrganizerModel>().ReverseMap();
            CreateMap<OrganizerCreateUpdateModel, Organizer>();
        }
    }
}
