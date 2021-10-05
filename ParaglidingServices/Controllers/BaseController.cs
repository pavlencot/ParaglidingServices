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
using System.Threading;

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
            where TCommand : Command<TInput, TOutput> where TOutput : BaseEntity
        {
            var command = HttpContext.RequestServices.GetRequiredService<TCommand>();
            var output = await command.Dispatch(input);
            await UnitOfWork.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, output.Id);
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

        protected async Task<ActionResult> ExecuteCommand<TCommand, TInput, TOutput>(TInput input)
            where TCommand : Command<TInput, TOutput> where TOutput : BaseEntity
        {
            var command = HttpContext.RequestServices.GetRequiredService<TCommand>();
            await command.Dispatch(input);
            await UnitOfWork.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult<TOutput>> ExecuteQuery<TQuery, TOutput>(CancellationToken cancellationToken)
            where TQuery : Query<TOutput>
        {
            var query = HttpContext.RequestServices.GetRequiredService<TQuery>();
            return await query.Dispatch(cancellationToken);
        }

        protected async Task<ActionResult<TOutput>> ExecuteQuery<TQuery, TInput, TOutput>(TInput input, CancellationToken cancellationToken)
            where TQuery : Query<TInput, TOutput>
        {
            var query = HttpContext.RequestServices.GetRequiredService<TQuery>();
            return await query.Dispatch(input, cancellationToken);
        }
    }
}
