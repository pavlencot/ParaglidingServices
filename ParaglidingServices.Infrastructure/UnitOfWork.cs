using Microsoft.AspNetCore.Http;
using ParaglidingServices.Core;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly HttpContext _httpContext;

        public UnitOfWork(AppDbContext dbContext, IHttpContextAccessor accessor)
        {
            _dbContext = dbContext;
            _httpContext = accessor.HttpContext;
        }
        public void AssertEntityAdded<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
