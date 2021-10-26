using AutoMapper;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Infrastructure.Models.Pilots;
using ParaglidingServices.Infrastructure.Models.Users;
using ParaglidingServices.Persistence.Data;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Infrastructure.Security
{
    public interface IRegistrationService
    {
        Task<Pilot> CreatePilot(PilotModel input);
        //Task<User> RegistratePilot(RegisterPilotModel model);

    }
    public class RegistrationService : IRegistrationService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public RegistrationService(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Pilot> CreatePilot(PilotModel input)
        {
            var pilot = _mapper.Map<Pilot>(input);

            await _dbContext.Pilots.AddAsync(pilot);

            return pilot;
        }

    }
}
