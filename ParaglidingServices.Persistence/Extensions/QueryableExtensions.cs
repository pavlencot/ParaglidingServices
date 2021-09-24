using ParaglidingServices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParaglidingServices.Core.Exceptions;

namespace ParaglidingServices.Persistence.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<TSource> SingleByIdOrDefaultAsync<TSource>(this IQueryable<TSource> src, long id/*,  CancellationToken cancellationToken = default */)
            where TSource : BaseEntity
        {
            return await src.SingleOrDefaultAsync(x => x.Id == id/*, cancellationToken*/) ??
                throw EntityNotFoundException.OfType<TSource>();
        }
    }
}
