using AutoMapper;
using ParaglidingServices.Domain.Entities.Auth;
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
            CreateMap<User, RegisterModel>()
                //.ForMember(r => r.Role, s => s.MapFrom(u => u.Role.Name))
                .ReverseMap();

            CreateMap<LoginModel, User>();
            CreateMap<UpdateProfileModel, User>();
            CreateMap<ChangePasswordModel, User>().ReverseMap();
        }
    }
}
