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
            CreateMap<CompetitionModel, Competition>().ReverseMap();
            CreateMap<CompetitionCreateUpdateModel, Competition>().ReverseMap();
        }
    }
}
