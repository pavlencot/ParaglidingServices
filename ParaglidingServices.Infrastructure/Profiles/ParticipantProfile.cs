using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Infrastructure.Models.Participants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Profiles
{
    public class ParticipantProfile : Profile
    {
        public ParticipantProfile()
        {
            CreateMap<ParticipantCreateModel, Participant>();

            CreateMap<Participant, ParticipantModel>()
                .ForMember(m => m.FirstName, n => n.MapFrom(o => o.Pilot.User.FirstName))
                .ForMember(m => m.LastName, n => n.MapFrom(o => o.Pilot.User.LastName))
                .ForMember(m => m.Category, n => n.MapFrom(o => o.Pilot.Licence.Category))
                .ForMember(m => m.CompetitionName, n => n.MapFrom(o => o.Competition.CompetitionName))
                .ReverseMap();

            CreateMap<Competition, ParticipantModel>()
                .ReverseMap();
            CreateMap<Licence, ParticipantModel>()
                .ReverseMap();
            CreateMap<User, ParticipantModel>()
                .ReverseMap();
        }
    }
}
