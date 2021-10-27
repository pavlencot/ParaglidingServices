using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Infrastructure.Models.Instructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Profiles
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<PilotInstructor, InstructorModel>()
                .ForMember(n => n.FirstName, o => o.MapFrom(p => p.User.FirstName))
                .ForMember(n => n.LastName, o => o.MapFrom(p => p.User.LastName))
                .ForMember(c => c.Country, d => d.MapFrom(e => e.Location.Country))
                .ForMember(l => l.LicenceNr, m => m.MapFrom(n => n.Licence.LicenceNr))
                .ForMember(a => a.Category, b => b.MapFrom(c => c.Licence.Category))
                .ForMember(i => i.IssuedOn, j => j.MapFrom(k => k.Licence.IssuedOn))
                .ForMember(v => v.ValidUntil, w => w.MapFrom(x => x.Licence.ValidUntil));

            CreateMap<InstructorCreateUpdateModel, PilotInstructor>()
                .ForMember(entity => entity.Licence, memberOptions => memberOptions.MapFrom(model => model));

            CreateMap<InstructorCreateUpdateModel, Licence>();

        }
    }
}
