using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure
{
    public abstract class Query<TOutput>
    {
        public abstract Task<TOutput> Dispatch(CancellationToken cancellationToken = default);
    }

    public abstract class Query<TInput, TOutput>
    {
        public abstract Task<TOutput> Dispatch(TInput input, CancellationToken cancellationToken = default);
    }

}
