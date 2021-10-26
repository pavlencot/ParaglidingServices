using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParaglidingServices.Api.Configuration;
using ParaglidingServices.Api.Helpers;
using ParaglidingServices.Api.Infrastructure.Security;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Infrastructure.Commands.Users;
using ParaglidingServices.Infrastructure.Models.Pilots;
using ParaglidingServices.Infrastructure.Models.Users;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly AuthOptions _authenticationOptions;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        public AccountsController(IOptions<AuthOptions> authenticationOptions, 
            SignInManager<User> signInManager, 
            UserManager<User> userManager,
            IMapper mapper,
            AppDbContext dbContext)
        {
            _authenticationOptions = authenticationOptions.Value;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var checkingPasswordResult = await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);

            if (checkingPasswordResult.Succeeded)
            {
                var signinCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                var jwtSecurityToken = new JwtSecurityToken(
                     issuer: _authenticationOptions.Issuer,
                     audience: _authenticationOptions.Audience,
                     claims: new List<Claim>(),
                     expires: DateTime.Now.AddDays(30),
                     signingCredentials: signinCredentials
                );

                var tokenHandler = new JwtSecurityTokenHandler();

                var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

                return Ok(new { AccessToken = encodedToken });
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register/pilot")]
        public async Task<IActionResult> RegisterPilot([FromBody]RegisterPilotModel model)
        {
            var userModel = model.UserModel;
            var pilotModel = model.PilotModel;

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    UserName = userModel.UserName,
                    PhoneNumber = userModel.PhoneNumber
                };

                var pilot = _mapper.Map<Pilot>(pilotModel);

                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, AuthorizeRole.Pilot);
                    await _dbContext.Pilots.AddAsync(pilot);
                    await _signInManager.SignInAsync(user, false);

                    return Ok(result);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return StatusCode(StatusCodes.Status422UnprocessableEntity);
        }

        [AllowAnonymous]
        [HttpPost("register/intructor")]
        public async Task<IActionResult> RegisterInstructor([FromBody] RegisterInstructorModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    UserName = userModel.UserName,
                    PhoneNumber = userModel.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, AuthorizeRole.PilotInstructor);
                    await _signInManager.SignInAsync(user, false);

                    return Ok(result);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return StatusCode(StatusCodes.Status422UnprocessableEntity);
        }

        [AllowAnonymous]
        [HttpPost("register/organizer")]
        public async Task<IActionResult> RegisterOrganizer([FromBody] RegisterOrganizerModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    UserName = userModel.UserName,
                    PhoneNumber = userModel.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, AuthorizeRole.Organizer);
                    await _signInManager.SignInAsync(user, false);

                    return Ok(result);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return StatusCode(StatusCodes.Status422UnprocessableEntity);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }

}
