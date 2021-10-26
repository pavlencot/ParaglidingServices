using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Infrastructure.Models.Pilots;
using ParaglidingServices.Infrastructure.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserModel, User>().ReverseMap();
            CreateMap<RegisterPilotModel, Pilot>()
                .ForMember(entity => entity.Licence, memberOptions => memberOptions.MapFrom(model => model))
                .ReverseMap();

            CreateMap<Pilot, PilotCreateUpdateModel>().ReverseMap();
            CreateMap<User, PilotCreateUpdateModel>()
                //.ForMember(r => r.Role, s => s.MapFrom(u => u.Role.Name))
                .ReverseMap();

            CreateMap<RegisterPilotModel, User>()
                .ForMember(entity => entity.Pilot, memberOptions => memberOptions.MapFrom(model => model))
                .ReverseMap();

            CreateMap<Pilot, RegisterPilotModel>().ReverseMap();
            CreateMap<Licence, RegisterPilotModel>().ReverseMap();



            CreateMap<LoginModel, User>().ReverseMap();


            CreateMap<UpdateProfileModel, User>();
            CreateMap<ChangePasswordModel, User>().ReverseMap();
        }
    }
}
