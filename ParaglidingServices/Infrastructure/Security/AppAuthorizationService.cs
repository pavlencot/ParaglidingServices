using Microsoft.AspNetCore.Identity;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Infrastructure.Constants;
using ParaglidingServices.Infrastructure.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Infrastructure.Security
{
    public interface IAppAuthorizationService
    {
        Task<IdentityResult> RegisterPilotAsync(RegisterModel model);
        Task<IdentityResult> RegisterOrganizerAsync(RegisterModel model);

        Task<IdentityResult> EditUserProfileAsync(UpdateProfileModel model);
        Task<string> SignInAsync(LoginModel model);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
        Task SignOutAsync();
    }
    public class AppAuthorizationService : IAppAuthorizationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtService _jwtService;

        public AppAuthorizationService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> EditUserProfileAsync(UpdateProfileModel model)
        {
            throw new NotImplementedException();
        }

        //correct and finish
        public async Task<IdentityResult> RegisterOrganizerAsync(RegisterModel model)
        {
            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.Phone,
            };
            var result = await _userManager.CreateAsync(user/*, password*/);


            return result;
        }

        public Task<IdentityResult> RegisterPilotAsync(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public Task<string> SignInAsync(LoginModel model)
        {
            throw new NotImplementedException();

        }

        private Task<string> View(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public async Task SignOutAsync() => await _signInManager.SignOutAsync();
    }
}
