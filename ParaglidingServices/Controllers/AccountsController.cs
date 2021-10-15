using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParaglidingServices.Api.Configuration;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Infrastructure.Models.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly AuthOptions _authenticationOptions;
        private readonly SignInManager<User> _signInManager;

        public AccountsController(IOptions<AuthOptions> authenticationOptions, SignInManager<User> signInManager)
        {
            _authenticationOptions = authenticationOptions.Value;
            _signInManager = signInManager;
        }

    }
}
