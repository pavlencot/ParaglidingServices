using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Profiles
{
    public class CompetitionProfile : Profile
    {
        public CompetitionProfile()
        {            
            CreateMap<CompetitionCreateUpdateModel, Competition>();

            CreateMap<Competition, CompetitionModel>()
                .ForMember(c => c.Location, d => d.MapFrom(e => e.Location.Country))
                .ReverseMap();
        }
    }
}
