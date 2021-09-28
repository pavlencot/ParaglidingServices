using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Core
{
    public interface IUnitOfWork
    {
        public void AssertEntityAdded<TEntity>(TEntity entity) where TEntity : class;
        public Task SaveChangesAsync();
    }
}
