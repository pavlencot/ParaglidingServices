using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure
{
    public abstract class Command
    {
        public abstract Task Dispatch();
    }

    public abstract class Command<TInput>
    {
        public abstract Task Dispatch(TInput input);
    }

    public abstract class Command<TInput, TOutput>
    {
        public abstract Task<TOutput> Dispatch(TInput input);
    }
}
