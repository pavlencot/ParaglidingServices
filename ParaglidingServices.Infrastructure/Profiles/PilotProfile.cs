using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Infrastructure.Models.Pilots;
using System;

namespace ParaglidingServices.Infrastructure.Profiles
{
    public class PilotProfile : Profile
    {
        public PilotProfile()
        {
            CreateMap<Pilot, PilotModel>()
                .ForMember(n => n.FirstName, o => o.MapFrom(p => p.User.FirstName))
                .ForMember(n => n.LastName, o => o.MapFrom(p => p.User.LastName))
                .ForMember(c => c.Country, d => d.MapFrom(e => e.Location.Country))
                .ForMember(l => l.LicenceNr, m => m.MapFrom(n => n.Licence.LicenceNr))
                .ForMember(a => a.Category, b => b.MapFrom(c => c.Licence.Category))
                .ForMember(i => i.IssuedOn, j => j.MapFrom(k => k.Licence.IssuedOn))
                .ForMember(v => v.ValidUntil, w => w.MapFrom(x => x.Licence.ValidUntil));

            CreateMap<PilotCreateUpdateModel, Pilot>()
                .ForMember(entity => entity.Licence, memberOptions => memberOptions.MapFrom(model => model))
                .ReverseMap();

            CreateMap<PilotCreateUpdateModel, Licence>().ReverseMap();
        }
    }
}
