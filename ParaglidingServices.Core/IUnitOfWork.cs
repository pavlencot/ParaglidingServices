using System.Threading.Tasks;

namespace ParaglidingServices.Core
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}
