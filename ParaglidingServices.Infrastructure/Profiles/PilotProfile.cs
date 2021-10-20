using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Pilots;
using System;

namespace ParaglidingServices.Infrastructure.Profiles
{
    public class PilotProfile : Profile
    {
        public PilotProfile()
        {
            CreateMap<Pilot, PilotModel>()
                .ForMember(c => c.Country, d => d.MapFrom(e => e.Location.Country))
                .ForMember(l => l.LicenceNr, m => m.MapFrom(n => n.Licence.LicenceNr))
                .ForMember(a => a.Category, b => b.MapFrom(c => c.Licence.Category));

            /*            CreateMap<PilotCreateUpdateModel, Pilot>()
                            .ForMember(l => l.Licence.LicenceNr, m => m.MapFrom(n => n.LicenceNr))
                            .ForMember(c => c.Licence.Category, d => d.MapFrom(e => e.Category))
                            .ForMember(i => i.Licence.IssuedOn, j => j.MapFrom(k => k.IssuedOn))
                            .ForMember(v => v.Licence.ValidUntil, w => w.MapFrom(x => x.ValidUntil));
            */
            CreateMap<PilotCreateUpdateModel, Pilot>()
                .ForMember(entity => entity.Licence, memberOptions => memberOptions.MapFrom(model => model))
                .ReverseMap();

            CreateMap<Licence, PilotCreateUpdateModel>().ReverseMap();
        }
    }
}
