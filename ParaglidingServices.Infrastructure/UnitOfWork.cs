using ParaglidingServices.Core;
using ParaglidingServices.Persistence.Data;
using System;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
