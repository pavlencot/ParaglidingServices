using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure
{
    public interface ICommand
    {
    }

    public interface ICommand<TOutput>
    {
    }

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task Dispatch(TCommand command);
    }

    public interface ICommandHandler<TCommand, TOutput> where TCommand : ICommand<TOutput>
    {
        Task<TOutput> Dispatch(TCommand command);
    }
}
