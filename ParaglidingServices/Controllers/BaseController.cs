using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using ParaglidingServices.Core;

namespace ParaglidingServices.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IUnitOfWork UnitOfWork => HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
        protected readonly IMapper _mapper;

        public BaseController()
        {

        }

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected async Task<ActionResult<long>> ExecuteCommandReturningEntityId<TCommand, TInput, TOutput>(TInput input)
            where TCommand : Command<TInput, TOutput>
        {
            var command = HttpContext.RequestServices.GetRequiredService<TCommand>();
            var output = await command.Dispatch(input);
            await UnitOfWork.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, output);
        }

        protected async Task<ActionResult> ExecuteCommand<TCommand>() where TCommand : Command
        {
            var command = HttpContext.RequestServices.GetRequiredService<TCommand>();
            await command.Dispatch();
            await UnitOfWork.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult> ExecuteCommand<TCommand, TInput>(TInput input)
            where TCommand : Command<TInput>
        {
            var command = HttpContext.RequestServices.GetRequiredService<TCommand>();
            await command.Dispatch(input);
            await UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
