using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParaglidingServices.Api.Configuration;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Infrastructure.Constants;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Infrastructure.Security
{
    public class JwtService
    {
        private readonly AuthOptions _authOptions;
        private readonly AppDbContext _dbContext;

        public JwtService(IOptions<AuthOptions> options, AppDbContext dbContext)
        {
            _authOptions = options.Value;
            _dbContext = dbContext;
        }

    }
}
