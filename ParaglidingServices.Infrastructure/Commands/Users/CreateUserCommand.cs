using AutoMapper;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Infrastructure.Commands.Pilots;
using ParaglidingServices.Infrastructure.Models.Users;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Commands.Users
{
    public class CreateUserCommand : Command<RegisterPilotModel, User>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommand(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override async Task<User> Dispatch(RegisterPilotModel input)
        {
            var user = _mapper.Map<User>(input);

            await _dbContext.Users.AddAsync(user);

            return user;
        }
    }
}
