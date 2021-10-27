using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Infrastructure.Models.Users;
using ParaglidingServices.Persistence.Data;
using System;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Infrastructure.Security
{
    public interface IAppAuthorizationService
    {
        Task<IdentityResult> RegisterPilotAsync(RegisterPilotModel model);
        Task<IdentityResult> RegisterInstructorAsync(RegisterPilotModel model);
        Task<IdentityResult> RegisterOrganizerAsync(RegisterPilotModel model);
        Task<string> SignInAsync(LoginModel model);
        Task SignOutAsync();
    }
    public class AppAuthorizationService : IAppAuthorizationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AppAuthorizationService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            AppDbContext dbContext, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IdentityResult> RegisterPilotAsync(RegisterPilotModel model)
        {
            var pilot = model.PilotModel;
            var user = model.UserModel;

            var pilotResult = _mapper.Map<Pilot>(pilot);
            var userResult = _mapper.Map<User>(user);

            await _dbContext.Users.AddAsync(userResult);

            var result = await _userManager.CreateAsync(userResult, user.Password);

            return result;
        }

        public Task<IdentityResult> RegisterInstructorAsync(RegisterPilotModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> RegisterOrganizerAsync(RegisterPilotModel model)
        {
            throw new NotImplementedException();
        }
        public Task<string> SignInAsync(LoginModel model)
        {
            throw new NotImplementedException();

        }

        public async Task SignOutAsync() => await _signInManager.SignOutAsync();
    }
}
